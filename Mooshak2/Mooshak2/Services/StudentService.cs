using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Services
{
    public class StudentService
    {
        private dbContext _db = new dbContext();

        public List<user> getAllStudents()
        {
            var result = (from n in _db.users
                          where n.userTypeID == 3
                          orderby n.name ascending
                          select n).ToList();

            return result;
        }
    }
}