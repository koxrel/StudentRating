using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Domain;
using StudentRating.Classes.Interfaces;

namespace StudentRating.Classes.Repositories
{
    public class TestRepository : IRepository
    {
        private static int _idHolder;

        public TestRepository()
        {
            _idHolder = 1;
            Courses = new List<Course>
            {
                new Course("Programming", 4.15),
                new Course("Geometry and algebra", 2),
                new Course("Theoretical bases of informatics", 3.9)
            };

            foreach (var course in Courses)
                course.Id = _idHolder++;

            Grades = new List<Grade>
            {
                new Grade(Courses[0], 7),
                new Grade(Courses[1], 5),
                new Grade(Courses[2], 10)
            };

            foreach (var grade in Grades)
                grade.Id = _idHolder++;
        }

        public List<Grade> Grades { get; }
        public List<Course> Courses { get; }
        public event Action GradesChanged;

        public void AddGrade(Grade grade)
        {
            if (grade == null)
                throw new ArgumentNullException();
            //Method List<T>.Contains(T obj) uses the overriden Equals methods for objects Grade and Course, therefore it is eligible
            if (Grades.Contains(grade))
                throw new ArgumentException();
            grade.Id = _idHolder++;
            Grades.Add(grade);

            Save();
            if (GradesChanged != null)
                GradesChanged.Invoke();
        }

        public void EditGrade(Grade grade)
        {
            if (grade == null)
                throw new ArgumentNullException();

            int index = Grades.IndexOf(grade);
            if (index != -1)
                Grades[index] = grade;

            Save();
            if (GradesChanged != null)
                GradesChanged.Invoke();
        }

        public void RemoveGrade(Predicate<Grade> p)
        {
            Grades.RemoveAll(p);

            Save();
            if (GradesChanged != null)
                GradesChanged.Invoke();
        }

        public void Save()
        {
            
        }
    }
}
