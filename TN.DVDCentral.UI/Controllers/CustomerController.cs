using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace TN.DVDCentral.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Customers";
            return View(CustomerManager.Load());
        }
        public IActionResult Details(Guid id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Details";
            return View(item);
        }

        public IActionResult Create()
        {
            if(Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create";
                return View();
            }
            
            else
            {
                return RedirectToAction("Login", "User", new {returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request)});
            }
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                int result = CustomerManager.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Edit(Guid id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = CustomerManager.LoadById(id);
                ViewBag.Title = "Edit";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Edit(Guid id, Customer customer, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Insert(customer, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(customer);
            }

        }

        public IActionResult Delete(Guid id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = CustomerManager.LoadById(id);
                ViewBag.Title = "Delete";
                return View(item);
            }
            
            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Customer customer, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(customer);
            }

        }
    }
}
