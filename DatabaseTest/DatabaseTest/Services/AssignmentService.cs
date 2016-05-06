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
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);

            if (assignment == null)
            {
                //TODO: Kasta villu
            }

            var milestones = _db.Milestones.Where(x => x.AssignmentID == assignmentID).Select(x => new AssignmentMilestoneViewModel { Title = x.Title }).ToList();

            var viewModel = new AssignmentViewModel
            {
                Title = assignment.Title,
                Milestones = milestones
            };

            return viewModel;
        }
    }
}