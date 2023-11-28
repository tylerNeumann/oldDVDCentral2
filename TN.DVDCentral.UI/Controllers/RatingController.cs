
using Microsoft.AspNetCore.Mvc;
namespace TN.DVDCentral.UI.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Ratings";
            return View(RatingManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = RatingManager.LoadById(id);
            ViewBag.Title = "Rating Details";
            return View(item);
        }

        public IActionResult Create() 
        {
            ViewBag.Title = "Create a rating";
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Rating rating)
        {
            try
            {
                int result = RatingManager.Insert(rating);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Edit(int id) 
        {
            var item = RatingManager.LoadById(id);
            ViewBag.Title = "Edit a rating";
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(int id, Rating rating, bool rollback = false)
        {
            try
            {
                int result = RatingManager.Insert(rating, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(rating);
            }
            
        }

        public IActionResult Delete(int id) 
        {
            var item = RatingManager.LoadById(id);
            ViewBag.Title = "Delete a rating";
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(int id, Rating rating, bool rollback = false)
        {
            try
            {
                int result = RatingManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(rating);
            }

        }
    }
}
