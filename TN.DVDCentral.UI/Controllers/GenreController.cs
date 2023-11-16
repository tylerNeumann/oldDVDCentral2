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
        public IActionResult Browse(int id)
        {
            return View(nameof(Index), GenreManager.Load(id));
        }
        public IActionResult Details(int id)
        {
            ViewBag.Title = "Detais";
            return View(GenreManager.LoadById(id));
        }

        public IActionResult Create() 
        {
            ViewBag.Title = "Create";
            return View(); 
        }

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
            var item = GenreManager.LoadById(id);
            ViewBag.Title = "Edit";
            return View(item);
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
            var item = GenreManager.LoadById(id);
            ViewBag.Title = "Delete";
            return View(item);
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
