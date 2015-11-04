using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRating.Classes.Domain
{
    [Serializable]
    public class Grade
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int Mark { get; set; }

        public Grade(Course course, int mark)
        {
            Course = course;
            Mark = mark;
        }

        public override bool Equals(object obj)
        {
            var gradeToCompare = obj as Grade;
            if (gradeToCompare == null)
                return false;
            //The method for comparing courses is already determined & implemented
            return Course.Equals(gradeToCompare.Course);
        }
    }
}
