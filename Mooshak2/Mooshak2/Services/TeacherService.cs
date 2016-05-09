using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Services
{
    public class TeacherService
    {
        private dbContext _db = new dbContext();

        public List<user> getStudentsInCourse(string course)
        {
            var students = (from s in _db.users
                            join sc in _db.studentCourses on s.ID equals sc.userID
                            join t in _db.userTypes on s.userTypeID equals t.ID
                            join c in _db.courses on sc.courseID equals c.ID
                            where t.type == "student"
                            && c.name == course
                            orderby s.name ascending
                            select s).ToList();

            return students;
        }
    }
}