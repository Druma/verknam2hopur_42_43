using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseTest.Services;

namespace DatabaseTest.Controllers
{
    public class AssignmentsController : Controller
    {
        private AssignmentService _service = new AssignmentService();

        // GET: Assignments
        public ActionResult Admin_Userlist_View()
        {
            return View();
        }

        public ActionResult Admin_Courses_View()
        {
            return View();
        }

        public ActionResult Admin_Errors_View()
        {
            return View();
        }

        public ActionResult Teacher_Options_View()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var viewModel = _service.GetAssignmentByID(id);

            return View(viewModel);
        }
    }
}