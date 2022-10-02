using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5Try3.Models
{
    public class borrows
    {
        public int borrowId { get; set; }
        public int bookId { get; set; }
        public string student { get; set; }
        public DateTime takenDate { get; set; }
        public DateTime broughtDate { get; set; }

    }
}