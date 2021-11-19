using MVCEFMidTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCEFMidTerm.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;

namespace MVCEFMidTerm.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students

        private StudentDbContext _context;
        public StudentsController()
        {
            _context = new StudentDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        //To view the student's list
        public ActionResult List()
        {
            List<Student> students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }

        //To create a new student record
        public ActionResult Create()
        {

            List<Course> courses = _context.Courses.ToList();
            StudentFormViewModel viewModel = new StudentFormViewModel
            {
                Student = new Student(),
                Courses = courses
            };
            return View("StudentForm", viewModel);
        }
        //To get the information about the particluar student from the database and
        //control pass on to the form to get the updated value
        public ActionResult Edit(int? id)
        {
            Student student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();
            StudentFormViewModel viewModel = new StudentFormViewModel
            {
                Student = student,
                Courses = _context.Courses.ToList()
            };

            return View("StudentForm", viewModel);
        }

        //To delete a paticular student record
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //Student student = _context.Students.SingleOrDefault(s => s.Id == id);
            Student student = _context.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("List", "Students");
        }

        //Either it's new record or the changes in the existing record, this action will triger to update the database
        [HttpPost]
        public ActionResult Update(Student student)
        {
            

            if (!ModelState.IsValid)
            {

                StudentFormViewModel viewModel = new StudentFormViewModel
                {
                    Student = student,
                    Courses = _context.Courses.ToList()
                };
                return View("StudentForm", viewModel);
            }
            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                Student studentInDb = _context.Students.Single(s => s.Id == student.Id);
                studentInDb.FirstName = student.FirstName;
                studentInDb.LastName = student.LastName;
                studentInDb.Birthdate = student.Birthdate;
                studentInDb.CourseId = student.CourseId;
                studentInDb.CourseEnrolledDate = student.CourseEnrolledDate;
                studentInDb.CourseStatus = student.CourseStatus;
                studentInDb.Grade = student.Grade;
                // _context.Entry(studentInDb).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return RedirectToAction("List", "Students");
        }

        //To fetch the details about the particular student
        public ActionResult Details(int? id)
        {
            var student = _context.Students.Include(s=>s.Course).SingleOrDefault(s=>s.Id==id);
            if (student == null) return HttpNotFound();
            return View("Details", student);
        }
    }
}