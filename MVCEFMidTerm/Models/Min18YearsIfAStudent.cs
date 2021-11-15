using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCEFMidTerm.Models;

namespace MVCEFMidTerm.Models
{
    public class Min18YearsIfAStudent:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;
            if (student.Birthdate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - student.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : 
                new ValidationResult("Student should be greater than 18 and above");
        }

    }
}