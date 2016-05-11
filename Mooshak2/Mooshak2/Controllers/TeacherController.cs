using Mooshak2.Services;
using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
	public class TeacherController : Controller
	{
		private TeacherService _teacherService = new TeacherService();
		private dbContext _db = new dbContext();
		// GET: Teacher
		public ActionResult Index()
		{
			//var students = new List<TeacherViewModel>();
			//students = _teacherService.getStudentsInCourse("Verklegt Námskeið 2");
			//return View(students);

			var model = new AssignmentViewModel
			{
				Courses = new SelectList(_teacherService.getTeacherCoursesByID(2), "CourseID", "Course")
			};
			return View(model);
		}

		// GET: Teacher/Details/5
		public ActionResult Details()
		{
			ViewBag.Message = "Your application description page.";
			return View();
		}

		// GET: Teacher/Create
		public ActionResult Create()
		{

			return View();
		}

		// POST: Teacher/Create
		//[HttpPost]
		//public ActionResult Create([Bind(Include = "Name,MaxSubmissions,GroupSize,AssignmentStart,AssignmentEnd,CourseID")] assignment assignment)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		_db.assignments.Add(assignment);
		//		_db.SaveChanges();
		//		return Json(assignment, JsonRequestBehavior.AllowGet);
		//	}
		//	return View(assignment);
		//}

		[HttpPost]
		public ActionResult Create(AssignmentViewModel newAssignment)
		{
			if (ModelState.IsValid)
			{
				_teacherService.addAssignment(newAssignment);
				return RedirectToAction("Index");
			}
			return Json(newAssignment, JsonRequestBehavior.AllowGet);
		}

	}
}
