﻿using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace TN.DVDCentral.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            ViewBag.Title = "Shopping Cart";
            cart = GetShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetShoppingCart()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return HttpContext.Session.GetObject<ShoppingCart>("cart");
            }
            else
            {
                return new ShoppingCart();
            }
        }

        public IActionResult Remove(int id)
        {
            cart = GetShoppingCart();

            Movie movie = cart.Items.FirstOrDefault(i => i.Id == id);

            ShoppingCartManager.Remove(cart, movie);
            HttpContext.Session.SetObject("cart", cart);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add(int id)
        {
            cart = GetShoppingCart();

            Movie movie = MovieManager.LoadById(id);

            ShoppingCartManager.Add(cart, movie);
            HttpContext.Session.SetObject("cart", cart);

            return RedirectToAction(nameof(Index), "Movie");
        }

        public IActionResult Checkout()
        {
            cart = GetShoppingCart();
            ShoppingCartManager.Checkout(cart);
            HttpContext.Session.SetObject("cart", null);
            return View();
        }
    }
}
