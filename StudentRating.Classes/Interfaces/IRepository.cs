﻿using System;
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
        //ICollection<T> is the lowest interface in the hierarchy that supports add/removal logic
        ICollection<Grade> Grades { get; }
        //IReadOnlyList<T> is the lowest interface in the hierarchy that supports indexing
        IReadOnlyList<Course> Courses { get; }

        event Action GradesChanged;

        void AddGrade(Grade grade);
        void EditGrade(Grade grade);
        void RemoveGrade(Predicate<Grade> p);

        void Save();
    }
}
