using DatabaseTest.Models.Entities;
using DatabaseTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseTest.Services
{
    public class StudentService
    {
        private dbConstext _db = new dbConstext();

        public List<user>getAllStudents()
        {
            var result = (from n in _db.users
                          where n.userTypeID == 3
                          orderby n.name ascending
                          select n).ToList();

            return result;
        }


    }
}