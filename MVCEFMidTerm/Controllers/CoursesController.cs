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
            
            return View(_context.Courses.ToList());
        }

        //To create a new course
        public ActionResult Create()
        {
            var course = new Course();
            return View("CourseForm",course);
        }

        //To edit the particluar record
        public ActionResult Edit(int id)
        {
            Course course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return HttpNotFound();
            
            return View("CourseForm", course);
        }

        //To delete the particluar record
        public ActionResult Delete(int id)
        {
            Course course = _context.Courses.SingleOrDefault(s => s.Id == id);
            if (course == null)
                return HttpNotFound();            
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("List", "Courses");
        }

        //Either create a  new record or edit the existing record ; this action will save back to the database
        [HttpPost]
        public ActionResult Update(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View("CourseForm");
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

        //Details about the paritcular course
        public ActionResult Details(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return HttpNotFound();
            return View("Details", course);
        }
    }
}
