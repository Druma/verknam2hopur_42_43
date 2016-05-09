using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public virtual userType UserType { get; set; }
    }
}