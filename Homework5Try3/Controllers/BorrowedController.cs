using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5Try3.Models;
using Service = Homework5Try3.Models.Service;

namespace Homework5Try3.Controllers
{
    public class BorrowedController : Controller
    {
        private Service dataService = new Service();
        // GET: Borrowed
        [HttpGet]
        public ActionResult Index(int id, string name)
        {
            ViewBag.BookName = name;
            ViewBag.BookId = id;
            var borrows = dataService.getAllBorrows(id).ToList();
            return View(borrows);
        }


    }
}