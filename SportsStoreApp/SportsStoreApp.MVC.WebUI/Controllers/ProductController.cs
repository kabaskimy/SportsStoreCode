using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Entities;
using SportsStoreApp.MVC.WebUI.Models;

namespace SportsStoreApp.MVC.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private  IProductRepository repository;
        public int pageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult List(string category,int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(m => category == null || m.Category == category).OrderBy(p => p.ProductId).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemPerPage = pageSize, TotalItems = repository.Products.Where(m => category == null || m.Category == category).Count() },
                CurrentCategory=category
            };
            //return View(repository.Products.OrderBy(m=>m.ProductID).Skip((page-1)*pageSize).Take(pageSize));
            return View(model);
        }

    }
}
