using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.ViewModels
{
    public class AdminViewModel
    {
		public string Name { get; set; }
        public string Username { get; set; }
		public string Password { get; set; }
		public string StudentName { get; set; }
		public string TeacherName { get; set; }
		public int TeacherID { get; set; }
		public int StudentID { get; set; }
		public int UserTypeID { get; set; }
		public string UserType { get; set; }
        public SelectList UserTypes { get; set; }
		public SelectList Teachers { get; set; }
		public SelectList Students { get; set; }

		public string Course { get; set; }
		public int CourseID { get; set; }
		public SelectList Courses { get; set; }
        
    }
}