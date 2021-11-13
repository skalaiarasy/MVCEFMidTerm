using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEFMidTerm.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string TutorName { get; set; }
        public int CourseRating { get; set; }
    }
}