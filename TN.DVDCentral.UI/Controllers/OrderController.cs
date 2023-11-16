using Microsoft.AspNetCore.Mvc;
using TN.DVDCentral.BL.Models;
namespace TN.DVDCentral.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
