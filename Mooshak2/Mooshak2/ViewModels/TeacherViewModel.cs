using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.ViewModels
{
	public class TeacherViewModel
	{
		public string Name { get; set; }
		public string Username { get; set; }
		public string Course { get; set; }
		public int CourseID { get; set; }
		public string Group { get; set; }
		public int Submission { get; set; }
		public SelectList Courses { get; set; }
	}
}