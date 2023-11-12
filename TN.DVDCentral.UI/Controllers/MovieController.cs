using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Movies";
            return View(MovieManager.Load());
        }
    }
}
