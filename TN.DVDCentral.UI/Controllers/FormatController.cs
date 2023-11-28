
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

        public IActionResult Create() { return View(); }

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
            var item = FormatManager.LoadById(id);
            ViewBag.Title = "Edita genre";
            return View(item);
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
            var item = FormatManager.LoadById(id);
            ViewBag.Title = "Deletea genre";
            return View(item);
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
