using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.UI.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Genres";
            return View(GenreManager.Load());
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
                ViewBag.Title = "Edit " + item.Description; ;
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
                ViewBag.Title = "Edit " + genre.Description;
                ViewBag.Error = ex.Message;
                return View(genre);
            }
            
        }

        public IActionResult Delete(int id) 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = GenreManager.LoadById(id);
                ViewBag.Title = "Delete " + item.Description;
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
                ViewBag.Title = "Delete " + genre.Description;
                ViewBag.Error = ex.Message;
                return View(genre);
            }

        }
    }
}
