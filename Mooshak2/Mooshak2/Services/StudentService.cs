using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Services
{
    
    public class StudentService
    {
        private dbContext _db;

        public StudentService()
        {
             _db = new dbContext();
        }
        public List<StudentViewModel> getAllStudents()
        {
            //var result = (from n in _db.users
            //              where n.userTypeID == 3
            //              orderby n.name ascending
            //              select n).ToList();

            var result = _db.users.Where(x => x.userTypeID == 3).Select(x => new StudentViewModel
            {
                Name = x.name
            }).ToList();

            return result;
        }

        public List<SelectListItem> GetAvailableAssignments()
        {
            List<SelectListItem> assignments = new List<SelectListItem>();

            assignments.Add(new SelectListItem() { Value = "", Text = "Assignments - " });

            _db.assignments.ToList().ForEach((x) =>
            {
                assignments.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.name });
            });

            return assignments;
        }

        public List<SelectListItem> GetAvailableSubAssignments()
        {
            List<SelectListItem> SubAssignments = new List<SelectListItem>();

            SubAssignments.Add(new SelectListItem() { Value = "", Text = "Assignments - " });

            _db.assignments.ToList().ForEach((x) =>
            {
                SubAssignments.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.name });
            });

            return SubAssignments;
        }
        

    }
}