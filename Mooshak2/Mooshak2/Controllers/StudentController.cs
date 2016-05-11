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

        private dbContext _db = new dbContext();

        // GET: Student
        public ActionResult Index()
        {
            StudentViewModel model = new StudentViewModel();
            model.AvailableAssignments = _studentService.GetAvailableAssignments();
            model.AvailableSubAssignments = _studentService.GetAvailableSubAssignments();
          //  var viewModel = _studentService.getAllStudents();
          //  studentViewModel.Name = viewModel.ToString();
            return View(model); //studentViewModel
        }

        
    }
}