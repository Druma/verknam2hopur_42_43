using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.ViewModels
{
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
    }
}