using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStoreApp.MVC.Domain.Entities;

namespace SportsStoreApp.MVC.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { set; get; }

        public string ReturnUrl { set; get; }
    }
}