using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCEFMidTerm.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Required]
        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }

        [Required]
        [Range(1,10,ErrorMessage ="Rate Must be between 1 to 10")]
        [Display(Name = "Course Rating")]
        public int CourseRating { get; set; }
    }
}