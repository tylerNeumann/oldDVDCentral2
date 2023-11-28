using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Genres";
            return View(GenreManager.Load());
        }
        public IActionResult Browse(int id)
        {
            return View(nameof(Index), GenreManager.Load(id));
        }
        public IActionResult Details(int id)
        {
            var item = GenreManager.LoadById(id);
            ViewBag.Title = "Genre Details";
            return View(item);
        }

        public IActionResult Create() 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create a genre";
                return View();
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            try
            {
                int result = GenreManager.Insert(genre);
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
                var item = GenreManager.LoadById(id);
                ViewBag.Title = "Edit a genre";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Edit(int id, Genre genre, bool rollback = false)
        {
            try
            {
                int result = GenreManager.Insert(genre, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(genre);
            }
            
        }

        public IActionResult Delete(int id) 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = GenreManager.LoadById(id);
                ViewBag.Title = "Delete a genre";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
            
        }
        [HttpPost]
        public IActionResult Delete(int id, Genre genre, bool rollback = false)
        {
            try
            {
                int result = GenreManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(genre);
            }

        }
    }
}
