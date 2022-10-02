using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5Try3.Models
{
    public class BooksVM
    {
        public List<authors> authors= new List<authors>();
        public List<books> books = new List<books>();
        public List<borrows> borrows= new List<borrows>();
        public List<students> students = new List<students>();
        public List<types> types = new List<types>();
    }
}