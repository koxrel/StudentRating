using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Domain;
using StudentRating.Classes.Interfaces;

namespace StudentRating.Classes.RatingCalculators
{
    public class StandartCalculator: IRatingCalculator
    {
        public double CalculateRating(List<Grade> grades)
        {
            double rating = 0;
            foreach (var g in grades)
                rating += g.Mark;
            return rating;
        }
    }
}
