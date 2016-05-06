using Mooshak2.ViewModels;
using Mooshak2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
    public class StudentController : Controller
    {
        private StudentService _studentService = new StudentService();

        // GET: Student
        public ActionResult Index()
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            var viewModel = _studentService.getAllStudents();
            studentViewModel.Name = viewModel.ToString();
            return View(studentViewModel);
        }
    }
}