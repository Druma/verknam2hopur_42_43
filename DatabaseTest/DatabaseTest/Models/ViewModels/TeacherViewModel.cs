using DatabaseTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseTest.Models.ViewModels
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