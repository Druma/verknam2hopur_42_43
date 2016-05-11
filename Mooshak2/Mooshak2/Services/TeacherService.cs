using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Services
{
	public class TeacherService
	{
		private dbContext _db;

		public TeacherService()
		{
			_db = new dbContext();
		}

		public List<TeacherViewModel> getAllStudents()
		{
			var students = (from n in _db.users
							join ut in _db.userTypes on n.userTypeID equals ut.ID
							where ut.type == "student"
							orderby n.name ascending
							select n).Select(x => new TeacherViewModel
							{
								Name = x.name,
								Username = x.username
							}).ToList();

			return students;
		}

		public TeacherViewModel getStudentByID(int studentID)
		{
			var student = (from u in _db.users
						   join ut in _db.userTypes on u.userTypeID equals ut.ID
						   where u.ID == studentID
						   && ut.type == "student"
						   select u).SingleOrDefault();

			var group = (from g in _db.groups
						 join u in _db.users on g.userID equals u.ID
						 where u.ID == studentID
						 select g.name).SingleOrDefault();

			var submissionCount = (from uas in _db.userAssignmentStats
								   join u in _db.users on uas.userID equals u.ID
								   where u.ID == studentID
								   select uas.submissionCount).SingleOrDefault();

			var viewModel = new TeacherViewModel
			{
				Name = student.name,
				Username = student.username,
				Group = group,
				Submission = submissionCount
			};

			return viewModel;
		}

		public List<TeacherViewModel> getStudentsInCourse(string course)
		{
			var result = (from n in _db.users
						  join g in _db.groups on n.ID equals g.userID
						  join uas in _db.userAssignmentStats on n.ID equals uas.userID
						  join ut in _db.userTypes on n.userTypeID equals ut.ID
						  join sc in _db.studentCourses on n.ID equals sc.userID
						  join c in _db.courses on sc.courseID equals c.ID
						  where ut.type == "student"
						  && c.name == course
						  && uas.submissionCount >= 0
						  orderby n.name ascending
						  select new { users = n, groups = g.name, userAssignmentStats = uas.submissionCount }).Select(x => new TeacherViewModel
						  {
							  Name = x.users.name,
							  Username = x.users.username,
							  Group = (x.groups == null ? " " : x.groups),
							  Submission = x.userAssignmentStats
						  }).ToList();

			return result;
		}

		public List<TeacherViewModel> getTeacherCoursesByID(int teacherID)
		{
			var courses = (from tc in _db.teacherCourses
						   join c in _db.courses on tc.courseID equals c.ID
						   where tc.userID == teacherID
						   select c).Select(x => new TeacherViewModel
						   {
							   CourseID = x.ID,
							   Course = x.name
						   }).ToList();

			return courses;
		}

		public void addAssignment(AssignmentViewModel newAssignment)
		{
			using (var context = new dbContext())
			{
				assignment model = new assignment
				{
					name = newAssignment.Name,
					maxSubmisions = newAssignment.MaxSubmissions,
					groupSize = newAssignment.GroupSize,
					startDate = newAssignment.AssignmentStart,
					endDate = newAssignment.AssignmentEnd,
					courseID = newAssignment.CourseID
				};
				context.assignments.Add(model);
				context.SaveChanges();
			}
		}
	}
}