using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View(MovieManager.Load());
        }
    }
}
