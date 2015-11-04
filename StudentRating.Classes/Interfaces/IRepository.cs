using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.Interfaces
{
    public interface IRepository
    {
        List<Grade> Grades { get; }
        List<Course> Courses { get; }

        event Action GradesChanged;

        void AddGrade(Grade grade);
        void EditGrade(Grade grade);
        void RemoveGrade(Predicate<Grade> p);

        void Save();
    }
}
