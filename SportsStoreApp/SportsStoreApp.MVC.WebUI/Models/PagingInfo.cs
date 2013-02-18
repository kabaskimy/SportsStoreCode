using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStoreApp.MVC.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { set; get; }

        public int ItemPerPage { set; get; }

        public int CurrentPage { get; set; }

        public int TotalPages 
        { 
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
            }
        }

    }
}