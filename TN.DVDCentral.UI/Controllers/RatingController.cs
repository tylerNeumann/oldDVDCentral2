using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
