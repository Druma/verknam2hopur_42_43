using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Services
{
    public class CoursesService
    {
        private dbContext _db;

        public CoursesService()
        {
            _db = new dbContext();
        }
        public List<CoursesViewModel> getAllCourses()
        {
            var result = _db.courses.Select(x => new CoursesViewModel
            {
                Name = x.name
            }).ToList();

            return result;
        }
    }
}