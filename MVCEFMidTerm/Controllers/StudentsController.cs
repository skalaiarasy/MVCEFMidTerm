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
        public ActionResult List()
        {
            List<Student> students = _context.Students.Include(s=>s.Course).ToList();
            return View(students);
        }
        public ActionResult Create()
        {
            
            List<Course> courses = _context.Courses.ToList();
            StudentFormViewModel viewModel = new StudentFormViewModel
            {
                Student = new Student(),
                Courses = courses
            };
            return View("StudentForm",viewModel);
        }
        public ActionResult Edit(int id)
        {
            Student student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();
            StudentFormViewModel viewModel = new StudentFormViewModel
            {
                Student = student,
                Courses = _context.Courses.ToList()
            };       
            
            return View("StudentForm",viewModel);
        }
        
        public ActionResult Delete(int? id)
        {
            Student student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();
            //_context.Entry(student).State = System.Data.Entity.EntityState.Deleted;
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("List","Students");
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            try
            {

                if (!ModelState.IsValid)
                {

                    StudentFormViewModel viewModel = new StudentFormViewModel
                    {
                        Student = student,
                        Courses = _context.Courses.ToList()
                    };
                    //return View("StudentForm", viewModel);
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
                    studentInDb.CourseId = student.CourseId;
                    studentInDb.CourseEnrolledDate = student.CourseEnrolledDate;
                    studentInDb.CourseStatus = student.CourseStatus;
                    studentInDb.Grade = student.Grade;
                    _context.Entry(studentInDb).State = EntityState.Modified;
                }
                
                _context.SaveChanges();
                return RedirectToAction("List", "Students");
            }
            catch(Exception ex)
            {
                var msg = ex.InnerException.Message;
                return View(msg);
            }
        }
    }
}