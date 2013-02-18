using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Entities;

namespace SportsStoreApp.MVC.WebUI.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/

        public PartialViewResult  Menu(string category=null)
        {
            //return "Hello From Menu Action";
            IEnumerable<string> categoryName = repository.Products.Select(m => m.Category).Distinct().OrderBy(m => m);
            ViewBag.SelectedCategory = category;
            return PartialView(categoryName);
        }

        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

    }
}
