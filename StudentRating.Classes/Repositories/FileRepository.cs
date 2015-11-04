using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Domain;
using StudentRating.Classes.Interfaces;

namespace StudentRating.Classes.Repositories
{
    public class FileRepository : IRepository
    {
        private static int _idHolder;

        public List<Grade> Grades { get; }
        public List<Course> Courses { get; }
        public event Action GradesChanged;

        public FileRepository()
        {
            _idHolder = 1;

            using (FileStream fsGrades = new FileStream("../../../StudentGrades.bin", FileMode.Open))
            {
                using (FileStream fsCourses = new FileStream("../../../StudentCourses.bin", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Courses = (List<Course>) bf.Deserialize(fsCourses);
                    Grades = (List<Grade>) bf.Deserialize(fsGrades);
                }
            }

            foreach (var grade in Grades)
                grade.Id = _idHolder++;

            foreach (var course in Courses)
                course.Id = _idHolder++;
        }

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
            using (FileStream fsGrades = new FileStream("../../../StudentGrades.bin", FileMode.Create))
            {
                using (FileStream fsCourses = new FileStream("../../../StudentCourses.bin", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fsCourses, Courses);
                    bf.Serialize(fsGrades, Grades);
                }
            }
        }
    }
}
