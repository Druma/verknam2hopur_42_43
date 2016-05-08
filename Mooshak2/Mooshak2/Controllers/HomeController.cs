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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
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

                if(user != null){
                    if(user.Password == crypto.Compute(password,user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }


            return isValid;
        }
    }
}