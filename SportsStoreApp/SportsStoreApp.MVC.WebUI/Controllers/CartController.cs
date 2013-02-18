using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Entities;
using SportsStoreApp.MVC.Domain.Concrete;
using SportsStoreApp.MVC.WebUI.Models;

namespace SportsStoreApp.MVC.WebUI.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository=repo;
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public RedirectToRouteResult AddToCart(Cart cart,int ProductId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(m => m.ProductId == ProductId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int ProductId, String returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(m => m.ProductId == ProductId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}
