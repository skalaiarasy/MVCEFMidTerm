using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEFMidTerm.Models;
using System.Data.Entity;
using MVCEFMidTerm.ViewModels;
namespace MVCEFMidTerm.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private StudentDbContext  _context;
        public CoursesController()
        {
            _context = new StudentDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            List<Course> courses = _context.Courses.ToList();
            
            return View(courses);
        }

        public ActionResult Create()
        {
            //List<Course> courses = _context.Courses.ToList();
            var course = new Course();
            return View("CourseForm",course);
        }
        public ActionResult Edit(int id)
        {
            Course course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return HttpNotFound();
            //StudentFormViewModel viewModel = new StudentFormViewModel
            //{
            //    Student = student,
            //    Courses = _context.Courses.ToList()
            //};


            return View("CourseForm", course);
        }

        public ActionResult Delete(int? id)
        {
            Course course = _context.Courses.SingleOrDefault(s => s.Id == id);
            if (course == null)
                return HttpNotFound();
            //_context.Entry(student).State = System.Data.Entity.EntityState.Deleted;
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("List", "Courses");
        }

        [HttpPost]
        public ActionResult Update(Course course)
        {
            if (!ModelState.IsValid)
            {
                //Course course = new Course();
                return View("CourseForm", course);
            }
            if (course.Id == 0)
            {
                _context.Courses.Add(course);
            }
            else
            {
                Course courseInDb = _context.Courses.Single(s => s.Id == course.Id);
                courseInDb.CourseName = course.CourseName;
                courseInDb.CourseDescription = course.CourseDescription;
                courseInDb.TutorName = course.TutorName;
                courseInDb.CourseRating = course.CourseRating;
                
            }
            _context.SaveChanges();
            return RedirectToAction("List", "Courses");
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}