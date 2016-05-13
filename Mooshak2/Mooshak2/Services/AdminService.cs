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
        public List<AdminViewModel> getAllUsers()
        {
			//List<SelectListItem> users = new List<SelectListItem>();

			//users.Add(new SelectListItem() {});

			//_db.courses.ToList().ForEach((x) =>
			//{
			//    users.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.name });
			//});

			var users = _db.users.Where(x => (x.userTypeID == 3 || x.userTypeID == 2)).Select(x => new AdminViewModel
			{
				Name = x.name
			}).ToList();

			return users;
        }

		public List<AdminViewModel> getUserTypes()
		{
			var types = (from ut in _db.userTypes
						 where ut.ID != 1
						 select ut).Select(x => new AdminViewModel
						 {
							 UserTypeID = x.ID,
							 UserType = x.type
						 }).ToList();

			return types;
		}

		public List<AdminViewModel> GetAllCourses()
        {
			//List<SelectListItem> courses = new List<SelectListItem>();

			//courses.Add(new SelectListItem() { Value = "", Text = "Assignments - " });

			//_db.courses.ToList().ForEach((x) =>
			//{
			//    courses.Add(new SelectListItem() { Value = x.ID.ToString(), Text = x.name });
			//});

			var courses = (from c in _db.courses
						   select c).Select(x => new AdminViewModel
						   {
							   CourseID = x.ID,
							   Course = x.name
						   }).ToList();

            return courses;
        }

		public List<AdminViewModel> getAllTeachers()
		{
			var teachers = (from u in _db.users
							join ut in _db.userTypes on u.userTypeID equals ut.ID
							where ut.type == "teacher"
							select u).Select(x => new AdminViewModel
							{
								TeacherID = x.ID,
								TeacherName = x.name
							}).ToList();

			return teachers;
		}

		public List<AdminViewModel> getAllStudents()
		{
			var students = (from u in _db.users
							join ut in _db.userTypes on u.userTypeID equals ut.ID
							where ut.type == "student"
							select u).Select(x => new AdminViewModel
							{
								TeacherID = x.ID,
								StudentName = x.name
							}).ToList();

			return students;
		}

		public void registerUser(AdminViewModel newUser)
		{
			using (var context = new dbContext())
			{
				user model = new user
				{
					name = newUser.Name,
					username = newUser.Username,
					password = newUser.Password,
					userTypeID = newUser.UserTypeID
				};
				context.users.Add(model);
				context.SaveChanges();
			}
		}

		public void linkTeacher(AdminViewModel teacherCourseLink)
		{
			using (var context = new dbContext())
			{
				teacherCours model = new teacherCours
				{
					userID = teacherCourseLink.TeacherID,
					courseID = teacherCourseLink.CourseID,
				};
				context.teacherCourses.Add(model);
				context.SaveChanges();
			}
		}

		public void linkStudent(AdminViewModel StudentCourseLink)
		{
			using (var context = new dbContext())
			{
				studentCours model = new studentCours
				{
					userID = StudentCourseLink.TeacherID,
					courseID = StudentCourseLink.CourseID,
				};
				context.studentCourses.Add(model);
				context.SaveChanges();
			}
		}
	}
}
