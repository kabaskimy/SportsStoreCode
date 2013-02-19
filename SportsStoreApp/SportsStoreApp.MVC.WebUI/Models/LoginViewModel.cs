using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportsStoreApp.MVC.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}