using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5Try3.Models;
using Service = Homework5Try3.Models.Service;

namespace Homework5Try3.Controllers
{
    public class StudentController : Controller
    {
        private Service dataService = new Service();
        // GET: Student
        [HttpGet]
        public ActionResult Index(int bookid, string bookName)
        {
            ViewBag.bookid = bookid;
            ViewBag.BookName = bookName;
            var student = dataService.getAllStudents().Distinct().ToList();
            return View(student);
        }

        [HttpPost]
        public ActionResult Index(string searchtext, string classs)
        {
            List<students> students = dataService.getAllStudents().Where(x => x.name.Contains(searchtext)).ToList();
            if(classs.Length != 0)
            {
                students = students.Where(x => x.classs.Contains(classs)).ToList();
            }
            return View(students);
        }
    }
}