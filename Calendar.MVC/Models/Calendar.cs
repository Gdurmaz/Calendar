using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.MVC.Models
{
    public class Calendar
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string StartingDate { get; set; }
        public string EndDate { get; set; }
    }
}