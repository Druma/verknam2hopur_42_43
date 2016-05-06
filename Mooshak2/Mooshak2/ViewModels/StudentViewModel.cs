using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.ViewModels
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public virtual userType UserType { get; set; }
        public virtual studentCours StudentCourse { get; set; }
        public virtual ICollection<studentCours> StudentCourses { get; set; }
    }
}