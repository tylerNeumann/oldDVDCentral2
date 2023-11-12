using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class DirectorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Directors";
            return View(DirectorManager.Load());
        }
        public IActionResult Browse(int id)
        {
            return View(nameof(Index),GenreManager.Load(id));
        }
        public IActionResult Details(int id) 
        { 
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Detais";
            return View(item);
        }

        public IActionResult Create() 
        {
            ViewBag.Title = "Create";
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Director director) 
        {
            try
            {
                int result = DirectorManager.Insert(director);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public IActionResult Edit(int id) 
        {
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Edit";
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(int id, Director director, bool rollback = false) 
        {
            try
            {
                int result = DirectorManager.Insert(director, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
            
        }

        public IActionResult Delete(int id) 
        {
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Delete";
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(int id, Director director, bool rollback = false) 
        {
            try
            {
                int result = DirectorManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
            
        }
    }
}
