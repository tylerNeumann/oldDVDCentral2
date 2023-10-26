using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class MovieController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
