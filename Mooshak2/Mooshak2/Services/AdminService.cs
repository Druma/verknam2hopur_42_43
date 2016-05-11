using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Services
{

    public class AdminService
    {
        private dbContext _db;

        public AdminService()
        {
            _db = new dbContext();
        }
        public List<SelectListItem> getAllUsers()
        {
            //var result = (from n in _db.users
            //              where n.userTypeID == 3
            //              orderby n.name ascending
            //              select n).ToList();

            List<SelectListItem> users = new List<SelectListItem>();

            users.Add(new SelectListItem() {});

            _db.courses.ToList().ForEach((x) =>
            {
                users.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.name });
            });

            return users;
        }

        public List<SelectListItem> GetAllCourses()
        {
            List<SelectListItem> courses = new List<SelectListItem>();

            courses.Add(new SelectListItem() { Value = "", Text = "Assignments - " });

            _db.courses.ToList().ForEach((x) =>
            {
                courses.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.name });
            });

            return courses;

            //var result = _db.courses.Select(x => new CoursesViewModel
            //{
            //    Name = x.name
            //}).ToList();

            //return result;
        }

        //public List<SelectListItem> GetAvailableSubAssignments()
        //{
        //    List<SelectListItem> SubAssignments = new List<SelectListItem>();

        //    SubAssignments.Add(new SelectListItem() { Value = "", Text = "Assignments - " });

        //    _db.assignments.ToList().ForEach((x) =>
        //    {
        //        SubAssignments.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.name });
        //    });

        //    return SubAssignments;
        //}


    }
}
