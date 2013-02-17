using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Entities;

namespace SportsStoreApp.MVC.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private  IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult List()
        {
            return View(repository.Products);
        }

    }
}
