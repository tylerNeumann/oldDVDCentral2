using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Linq;
using System.Xml.Linq;
using TN.DVDCentral.BL.Models;
using TN.DVDCentral.UI.ViewModels;

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
            if (Authentication.IsAuthenticated(HttpContext))
            {
                cart = GetShoppingCart();
                //IEnumerable<int> userid = new List<int>();
                //userid = GetObject();
                //IEnumerable<int> oldGenreIds = new List<int>();
                //oldGenreIds = GetObject();
                //int userid = 0;
                //userid.ToList().ForEach(u =>ShoppingCartManager.Checkout(cart,u));
                OrdersVM ordersVM = new OrdersVM();
                ShoppingCartManager.Checkout(cart);
                HttpContext.Session.SetObject("cart", null);
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        private IEnumerable<int> GetObject()//might not be string
        {
            if (HttpContext.Session.GetObject<IEnumerable<int>>("user") != null)
            {
                return HttpContext.Session.GetObject<IEnumerable<int>>("user");
            }
            else
            {
                return null;
            }
        }
    }
}
