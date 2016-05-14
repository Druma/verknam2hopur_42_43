using Mooshak2.Services;
using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Mooshak2.Controllers
{
    public class HomeController : Controller
    {
        private dbContext _db = new dbContext();
        private StudentService _studentService = new StudentService();

        public ActionResult GetUsernameFromDataBase(int? id)
        {
            //Student student = new Student { Name = "Patrekur", Age = 27 };
            // StudentViewModel valli = new StudentViewModel { Name = "DANIEL FREYR" };
            StudentService theUser = new StudentService();
            string lookingForTheUser = theUser.GetUserName();
            return Json(lookingForTheUser, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ValidateUser(string userid, string password)
        {
            var data = from c in _db.users where c.username == userid && c.password == password select c;
            if (data.Count() > 0)
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult IndexTest()
        {
            return View();
        }

        public ActionResult Login(LoginInfo LoginInfo)
        {
            if (ModelState.IsValid)
            {
                if (_studentService.UserIsLogedIn(LoginInfo.Username, LoginInfo.Password))
                {
                    StudentViewModel model = new StudentViewModel();
                    model.AvailableAssignments = _studentService.GetAvailableAssignments();
                    model.AvailableSubAssignments = _studentService.GetAvailableSubAssignments();
                    model.Name = _studentService.GetUser(LoginInfo.Username, LoginInfo.Password).name;
                    model.Username = _studentService.GetUser(LoginInfo.Username, LoginInfo.Password).username;
                    return View("~/Views/Student/Index.cshtml", model);
                }
                else
                {
                    LoginInfo.UserDidNotGetLoggedIn = true;
                    return View("~/Views/Home/Index.cshtml", LoginInfo);
                }
            }
            LoginInfo.UserDidNotGetLoggedIn = false;
            return View("~/Views/Home/Index.cshtml", LoginInfo);
        }

        [HttpGet]
        public ActionResult Index()
        {
            LoginInfo LoginInfo = new LoginInfo();
            LoginInfo.UserDidNotGetLoggedIn = false;
            return View("~/Views/Home/Index.cshtml", LoginInfo);

        }

        [HttpPost]
        public ActionResult Index(Mooshak2.ViewModels.UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Username, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is Incorrect");
                }
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Mooshak2.ViewModels.UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (var _db = new VLN2_2016_H42Entities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(user.Password);

                    var sysUser = _db.SystemUsers.Create();

                    sysUser.Username = user.Username;
                    sysUser.Password = encrpPass;
                    sysUser.PasswordSalt = crypto.Salt;
                    sysUser.UserId = Guid.NewGuid();

                    _db.SystemUsers.Add(sysUser);
                    _db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }

            else
            {
                ModelState.AddModelError("", "Login Data is incorret.");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;

            using (var _db = new VLN2_2016_H42Entities())
            {
                var user = _db.SystemUsers.FirstOrDefault(u => u.Username == email);

                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }


            return isValid;
        }
    }
}