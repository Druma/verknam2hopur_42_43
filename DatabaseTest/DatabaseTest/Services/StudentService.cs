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
        private dbConstext db = new dbConstext();

        public List<user>getNames()
        {
            var result = (from n in db.users
                          select n).ToList();

            return result;
        }
    }
}