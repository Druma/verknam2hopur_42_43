using Mooshak2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Services
{

    public class UserService
    {
        private dbContext _db;

        public UserService()
        {
            _db = new dbContext();
        }
        public List<UserViewModel> getAllUsers()
        {
            //var result = (from n in _db.users
            //              where n.userTypeID == 3
            //              orderby n.name ascending
            //              select n).ToList();

            var result = _db.users.Where(x => (x.userTypeID == 3 || x.userTypeID == 2)).Select(x => new UserViewModel
            {
                Name = x.name
            }).ToList();

            return result;
        }
    }
}