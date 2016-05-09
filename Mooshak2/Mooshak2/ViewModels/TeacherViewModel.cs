using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.ViewModels
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public virtual userType UserType { get; set; }
        public virtual teacherCours TeacherCours { get; set; }
        public virtual ICollection<teacherCours> TeacherCourses { get; set; }
    }
}