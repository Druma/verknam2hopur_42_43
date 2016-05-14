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

        public bool UserIsLogedIn(string username, string password)
        {
            var gaur = _db.users.Where(p => p.username == username && p.password == password).ToList();
            if (gaur.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public user GetUser(string username, string password)
        {
            var gaur = _db.users.Where(p => p.username == username && p.password == password).ToList();
            return gaur.First();
        }

        public string IsUserNameAndPasswordInDataBase(LoginInfo para)
        {


            string User = (from n in _db.users
                           where n.username == para.Username
                           select n).FirstOrDefault().ToString();

            string Pass = (from n in _db.users
                           where n.password == para.Password
                           select n).FirstOrDefault().ToString();
            if (para.Username == User && para.Password == Pass)
            {
                return "success";

            }
            return "";


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

        public List<SelectListItem> SubAssignmentsById(int Id)
        {
            List<SelectListItem> SubAssignments = new List<SelectListItem>();

            _db.assignmentParts.Where(p => p.assignmentID == Id).ToList().ForEach(x =>
            {
                SubAssignments.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.descriptoin });
            });

            return SubAssignments;
        }

        public string GetUserName()
        {
            string daniel = "daniel freyr sigurdsson";
            return daniel;
        }


    }
}