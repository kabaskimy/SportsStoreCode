using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportsStoreApp.MVC.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage="Please enter the Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage="Please enter the Description")]
        public string Description { set; get; }

        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage="Please enter a positive value")]
        public decimal Price { set; get; }

        [Required(ErrorMessage="Please specify a category")]
        public string Category { set; get; }

        public byte[] ImageData { set; get; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { set; get; }
    }
}
