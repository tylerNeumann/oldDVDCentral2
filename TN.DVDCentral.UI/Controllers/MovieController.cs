
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TN.DVDCentral.UI.ViewModels;

namespace TN.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IWebHostEnvironment _host;
        public MovieController(IWebHostEnvironment host)
        {
            _host = host;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "List of Movies";
            return View(MovieManager.Load());
        }
        public IActionResult Browse(int id)
        {
            var results = GenreManager.LoadById(id);
            ViewBag.Title = "List of " + results.Description + " movies";
            return View(nameof(Index), MovieManager.Load(id));
        }
        public IActionResult NullViewModel()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var item = MovieManager.LoadById(id);
            ViewBag.Title = "Detais";
            return View(item);
        }

        public IActionResult Create()
        {


            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create a movie";
                MovieVM movieVM = new MovieVM();

                movieVM.Movie = new Movie();

                movieVM.FormatList = FormatManager.Load();
                movieVM.RatingList = RatingManager.Load();
                movieVM.GenreList = GenreManager.Load();
                movieVM.DirectorList = DirectorManager.Load();

                return View(movieVM);
            }
            else return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            
        }

        [HttpPost]
        public IActionResult Create(MovieVM movieVM)
        {
            try
            {
                int result = MovieManager.Insert(movieVM.Movie);
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
                MovieVM movieVM = new MovieVM();

                if (movieVM != null)
                {
                    
                    movieVM.Movie = MovieManager.LoadById(id);

                    movieVM.FormatList = FormatManager.Load();
                    movieVM.RatingList = RatingManager.Load();
                    movieVM.GenreList = GenreManager.Load();
                    movieVM.DirectorList = DirectorManager.Load();

                    ViewBag.Title = "Edit " + movieVM.Movie.Title;

                    return View(movieVM);
                }
                else
                {
                    return RedirectToAction(nameof(NullViewModel));
                }
                
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Edit(int id, MovieVM movieVM, bool rollback = false)
        {
            try
            {
                if (movieVM.File != null)
                {
                    movieVM.Movie.ImagePath = movieVM.File.FileName;
                    string path = _host.WebRootPath + "\\images\\";
                    using (var stream = System.IO.File.Create(path + movieVM.File.FileName))
                    {
                        movieVM.File.CopyTo(stream);
                        ViewBag.Message = "file uploaded successfully...";
                    }
                }
                int result = MovieManager.Update(movieVM.Movie, rollback);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movieVM);
            }
        }

        public IActionResult Delete(int id)
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = MovieManager.LoadById(id);
                ViewBag.Title = "Delete";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }

        }
        [HttpPost]
        public IActionResult Delete(int id, Movie movie, bool rollback = false)
        {
            try
            {
                int result = MovieManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movie);
            }

        }
    }
}
