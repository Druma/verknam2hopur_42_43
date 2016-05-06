using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseTest.Models.Entities;
using DatabaseTest.Models;
using DatabaseTest.Services;
using DatabaseTest.Models.ViewModels;

namespace DatabaseTest.Controllers
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