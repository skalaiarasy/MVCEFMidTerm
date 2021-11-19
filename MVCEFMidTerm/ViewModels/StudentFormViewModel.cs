﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCEFMidTerm.Models;
using System.Collections.Generic;

namespace MVCEFMidTerm.ViewModels
{
    public class StudentFormViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public string Title
        {
            get
            {
                if (Student != null && Student.Id != 0)
                {
                    return "Edit Student";
                }
                else
                {
                    return "New Student";
                }



            }
        }
    }
}