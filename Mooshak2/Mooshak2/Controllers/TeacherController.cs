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

			var model = new TeacherViewModel
			{
				Courses = new SelectList(_teacherService.getAllCourses(), "CourseID", "Course")
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
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Teacher/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Teacher/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Teacher/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Teacher/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
