using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5Try3.Models;
using Service = Homework5Try3.Models.Service;

namespace Homework5Try3.Controllers
{
    public class BorrowBookController : Controller
    {
        private Service dataService = new Service();
        // GET: BorrowBook
        [HttpGet]
        public ActionResult Index(int bookId, string bookName)
        {
            ViewBag.BookName = bookName;
            ViewBag.BookId = bookId;
            var borrows = dataService.getAllBorrows(bookId).ToList();
            return View(borrows);
        }
    }
}