using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Homework5Try3.Models;
using Service = Homework5Try3.Models.Service;

namespace Homework5Try3.Controllers
{
    public class HomeController : Controller
    {
        private Service dataService = new Service();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            List<books> books = dataService.getAllBooks();  
            return View(books);
        }

        [HttpPost]
        public ActionResult Index(string searchtext, string author,string type)
        {
            
            List<books> books = dataService.getAllBooks().Where(x => x.name.Contains(searchtext)).ToList();
            if(author.Length != 0)
            {
                books = books.Where(x => x.author.Contains(author)).ToList();
                
            }
            if(type.Length != 0)
            {
                books = books.Where(x => x.type.Contains(type)).ToList();
            }
            return View(books);
        }
    }
}