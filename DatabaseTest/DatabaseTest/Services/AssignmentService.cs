using DatabaseTest.Models;
using DatabaseTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseTest.Services
{
    public class AssignmentService
    {
        private ApplicationDbContext _db;

        public AssignmentService()
        {
            _db = new ApplicationDbContext();
        }

        public List<AssignmentViewModel> GetAssignmentsInCourse(int assignmentID)
        {
            //TODO
            return null;
        }

        public AssignmentViewModel GetAssignmentByID(int assignmentID)
        {
            

            return null;
        }
    }
}