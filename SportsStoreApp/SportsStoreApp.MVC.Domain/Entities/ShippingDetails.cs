using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStoreApp.MVC.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage="Please Enter A Name")]
        public string Name { set; get; }


        [Required(ErrorMessage="Please Enter The First Address Line")]
        public string Line1 { set; get; }
        public string Line2 { set; get; }
        public string Line3 { set; get; }

        [Required(ErrorMessage = "Please Enter A City Name")]
        public string City { set; get; }

        [Required(ErrorMessage = "Please Enter A State")]
        public string State { set; get; }

        public string Zip { set; get; }

        [Required(ErrorMessage = "Please Enter A Country Name")]
        public string Country { set; get; }

        public bool GiftWrap { get; set; }
    }
}
