using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TN.DVDCentral.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login";
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                bool result = UserManager.Login(user);
                SetUser(user);
                if (TempData["returnUrl"] != null)  return Redirect(TempData["returnUrl"]?.ToString()); 
                return RedirectToAction(nameof(Index), "Movie");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }
        public IActionResult LogOut()
        {
            ViewBag.Title = "Logout";
            SetUser(null);
            return View();
        }
        private void SetUser(User user)
        {
            HttpContext.Session.SetObject("user", user);
            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + user.FullName);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }
        public IActionResult Create()
        {

                ViewBag.Title = "Create a user";
                return View();

        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                int result = UserManager.Insert(user);
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
                var item = UserManager.LoadById(id);
                ViewBag.Title = "Edit a user";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, User user, bool rollback = false)
        {
            try
            {
                int result = UserManager.Insert(user, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }

        }

        public IActionResult DeleteAll()
        {
            var item = UserManager.DeleteAll();
            ViewBag.Title = "Delete all users";
            return View(item);
        }
        [HttpPost]
        public IActionResult DeleteAll(User user, bool rollback = false)
        {
            try
            {
                int result = UserManager.DeleteAll();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }

        }
    }
}
