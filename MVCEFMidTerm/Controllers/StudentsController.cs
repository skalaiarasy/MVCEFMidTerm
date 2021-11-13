using MVCEFMidTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }
    }
}