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
            model.Name = "Apamaður";
            model.Username = "apamadurinn";

            return View(model);
        }

        // /Student/GetAssignmentParts?Id=2
        [HttpGet]
        public ActionResult GetAssignmentParts(int Id)
        {
            StudentService gaur = new StudentService();

            List<SelectListItem> Listi = gaur.SubAssignmentsById(Id);


            return Json(Listi, JsonRequestBehavior.AllowGet);
        }


    }
}
