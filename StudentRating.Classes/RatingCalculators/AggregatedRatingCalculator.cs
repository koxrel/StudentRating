using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Domain;
using StudentRating.Classes.Interfaces;

namespace StudentRating.Classes.RatingCalculators
{
    public class AggregatedRatingCalculator : IRatingCalculator
    {
        public double CalculateRating(List<Grade> grades)
        {
            return grades.Sum(grade => grade.Mark*grade.Course.Credits);
        }
    }
}
