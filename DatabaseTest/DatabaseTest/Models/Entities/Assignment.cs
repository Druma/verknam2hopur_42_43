using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseTest.Models.Entities
{
    public class Assignment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Title { get; set; }
    }
}