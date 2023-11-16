using Microsoft.AspNetCore.Mvc;
using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
