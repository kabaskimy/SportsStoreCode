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
        private IOrderProcessor orderProcessor;
        public CartController(IProductRepository repo,IOrderProcessor processor)
        {
            repository=repo;
            orderProcessor = processor;
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

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(Cart cart, ShippingDetails details)
        {
            if (cart.Lines.Count() <= 0)
            {
                ModelState.AddModelError("NoItem", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, details);
                cart.Clear();
                return View("Completed");
            }

            else
            {
                return View(details);
            }
        }
    }
}
