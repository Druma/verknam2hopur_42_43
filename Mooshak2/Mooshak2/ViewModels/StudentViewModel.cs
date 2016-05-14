using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.ViewModels
{

    public class LoginInfo
    {
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public bool UserDidNotGetLoggedIn { get; set; }

        public LoginInfo()
        {
            UserDidNotGetLoggedIn = false;
        }
    }

    public class StudentViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public int UserTypeID { get; set; }
        public int StudentCourseID { get; set; }
        public virtual ICollection<studentCours> StudentCourses { get; set; }
        //List of available assignments
        public List<SelectListItem> AvailableAssignments { get; set; }
        //List of available sub-assignments
        public List<SelectListItem> AvailableSubAssignments { get; set; }

        public string SubmittedCode { get; set; }
    }
}