
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class FormatController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Formats";
            return View(FormatManager.Load());
        }

        public IActionResult Details(int id)
        {
            ViewBag.Title = "Format Details";
            return View(FormatManager.LoadById(id));
        }

        public IActionResult Create() 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create a format";
                return View();
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }

        [HttpPost]
        public IActionResult Create(Format format)
        {
            try
            {
                int result = FormatManager.Insert(format);
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
                var item = FormatManager.LoadById(id);
                ViewBag.Title = "Edit a format";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Edit(int id, Format format, bool rollback = false)
        {
            try
            {
                int result = FormatManager.Insert(format, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(format);
            }
            
        }

        public IActionResult Delete(int id) 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = FormatManager.LoadById(id);
                ViewBag.Title = "Delete a format";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Delete(int id, Format format, bool rollback = false)
        {
            try
            {
                int result = FormatManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(format);
            }

        }
    }
}
