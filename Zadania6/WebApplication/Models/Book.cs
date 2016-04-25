using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Book
    {
        public int Id { set; get; }
        public string BookTitle { set; get; }
        public string ISBN { set; get; }
        public int PageCount { set; get; }
    }
}