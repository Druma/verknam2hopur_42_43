using Mooshak2.Services;
using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
    public class AdminController : Controller
    {
        private UserService _userService = new UserService();
        private CoursesService _coursesService = new CoursesService();
		private AdminService _adminService = new AdminService();
        private dbContext _db = new dbContext();
        // GET: Admin
        public ActionResult Index()
        {
			//var userViewModel = new List<UserViewModel>();
			//var viewModel = _userService.getAllUsers();
			//userViewModel = viewModel;
			//return View(viewModel);

			var model = new AdminViewModel
			{
				UserTypes = new SelectList(_adminService.getUserTypes(), "UserTypeID", "UserType"),
				Courses = new SelectList(_adminService.GetAllCourses(), "CourseID", "Course")
			};

			return View(model);
		}

        // GET: Admin/Details/5
        public ActionResult Courses()
        {
			//var coursesViewModel = new List<CoursesViewModel>();
			//var viewModel = _coursesService.getAllCourses();
			//coursesViewModel = viewModel;
			//return View(viewModel);

			var model = new AdminViewModel
			{
				Teachers = new SelectList(_adminService.getAllTeachers(), "TeacherID", "TeacherName"),
				Courses = new SelectList(_adminService.GetAllCourses(), "CourseID", "Course"),
				Students = new SelectList(_adminService.GetAllCourses(), "StudentID", "StudentName")
			};

			return View(model);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Register(AdminViewModel newUser)
        {
			if (ModelState.IsValid)
			{
				_adminService.registerUser(newUser);
				return RedirectToAction("Index");
			}

			return Json(newUser, JsonRequestBehavior.AllowGet);
		}

        [HttpPost]
		public ActionResult LinkTeacher(AdminViewModel teacherToLink)
		{
			if(ModelState.IsValid)
			{
				_adminService.linkTeacher(teacherToLink);
				return RedirectToAction("Courses");
			}
			return Json(teacherToLink, JsonRequestBehavior.AllowGet);
		}

		public ActionResult LinkStudent(AdminViewModel studentToLink)
		{
			if (ModelState.IsValid)
			{
				_adminService.linkTeacher(studentToLink);
				return RedirectToAction("Courses");
			}
			return Json(studentToLink, JsonRequestBehavior.AllowGet);
		}
	}
}
