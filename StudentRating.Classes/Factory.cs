using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.RatingCalculators;
using StudentRating.Classes.Repositories;

namespace StudentRating.Classes
{
    public class Factory
    {
        private Factory() {}

        private static Factory _factory;

        public static Factory GetFactory
        {
            get
            {
                if (_factory == null)
                    _factory = new Factory();
                return _factory;
            }
        }

        public IRepository GetRepository()
        {
            return new FileRepository();
        }

        public IRatingCalculator GetCalculator()
        {
            return new AggregatedRatingCalculator();
        }
    }
}
