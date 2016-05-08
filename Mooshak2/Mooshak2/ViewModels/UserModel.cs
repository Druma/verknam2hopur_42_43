using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mooshak2.ViewModels
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name="Username")] //Displays a text string in the textbox
        public string Username { get; set; } //Email

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength=6)]
        [Display(Name = "Password")] //Displays a text string in the textbox
        public string Password { get; set; }

        //maybe we dont need this
       // public string PasswordSalt { get; set; }

    }
}