using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseTest.Models.Entities;
using DatabaseTest.Models;
using DatabaseTest.Services;

namespace DatabaseTest.Controllers
{
    public class StudentController : Controller
    {
        private StudentService _userService = new StudentService();

        // GET: Student
        public ActionResult Index()
        {
            var viewModel = _userService.getNames();
            return View();
        }
    }
}