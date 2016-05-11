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
		public string Name { get; set; }
		public int MaxSubmissions { get; set; }
		public int GroupSize { get; set; }
		public DateTime AssignmentStart { get; set; }
		public DateTime AssignmentEnd { get; set; }
		public string Course { get; set; }
		public SelectList Courses { get; set; }
		public int CourseID { get; set; }
		//public IEnumerable<SelectList> CourseID { get; set; }

		//[Required]
		//public string Name { get; set; }
		//public int MaxSubmissions { get; set; }
		//public int GroupSize { get; set; }

		//[Required]
		//[DataType(DataType.DateTime)]
		//public DateTime AssignmentStart { get; set; }

		//[Required]
		//[DataType(DataType.DateTime)]
		//public DateTime AssignmentEnd { get; set; }
		//public string Course { get; set; }
		//public SelectList Courses { get; set; }

		//[Required]
		//public int CourseID { get; set; }
	}
}