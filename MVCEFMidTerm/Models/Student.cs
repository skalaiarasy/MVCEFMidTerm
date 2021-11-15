using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCEFMidTerm.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Student's name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public Course Course { get; set; }

        [Required(ErrorMessage = "Please enter course name")]
        [Display(Name ="Course Name")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Course Enrolled Date")]
        public DateTime? CourseEnrolledDate { get; set; }

        [Required]
        [Display(Name = "Course Status")]
        public int CourseStatus { get; set; }

        [Required]
        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAStudent]
        public DateTime? Birthdate { get; set; }
    }
}