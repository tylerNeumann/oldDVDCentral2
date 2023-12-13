using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TN.DVDCentral.UI.ViewModels;
namespace TN.DVDCentral.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Orders";
            return View(OrderManager.Load());
        }
        public IActionResult Details(int id)
        {
            OrdersVM ordersVM = new OrdersVM(id);
            HttpContext.Session.SetObject("customerids", ordersVM.CustomerIds);
            
            ViewBag.Title = "Order Details";
            return View(ordersVM);
        }

        public IActionResult Create()
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create an order";
                return View();
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            try
            {
                int result = OrderManager.Insert(order);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Edit(int id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = OrderManager.LoadById(id);
                ViewBag.Title = "Edit an order";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Edit(int id, Order order, bool rollback = false)
        {
            try
            {
                int result = OrderManager.Insert(order, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(order);
            }

        }

        public IActionResult Delete(int id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = OrderManager.LoadById(id);
                ViewBag.Title = "Delete an order";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Delete(int id, Order order, bool rollback = false)
        {
            try
            {
                int result = OrderManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(order);
            }

        }
    }
}
