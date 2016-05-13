using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.ViewModels
{
	public class AssignmentViewModel
	{
		//Assignment
		public string Name { get; set; }
		public int MaxSubmissions { get; set; }
		public int GroupSize { get; set; }
		public DateTime AssignmentStart { get; set; }
		public DateTime AssignmentEnd { get; set; }
		public string Course { get; set; }
		public SelectList Courses { get; set; }
		public int CourseID { get; set; }

		//Assignemnt Part.
		public string Description { get; set; }
		public string SolutionFile { get; set; }
		public int AssignmentID { get; set; }
	}
}