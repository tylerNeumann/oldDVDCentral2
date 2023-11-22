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
        public IActionResult Details(int id)
        {
            ViewBag.Title = "Detais";
            return View(CustomerManager.LoadById(id));
        }

        public IActionResult Create()
        {
            if(Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create";
                return View(nameof(Create));
            }
            
            else
            {
                return RedirectToAction("Login", "User");
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

        public IActionResult Edit(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Edit";
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer customer, bool rollback = false)
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

        public IActionResult Delete(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Delete";
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(int id, Customer customer, bool rollback = false)
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
