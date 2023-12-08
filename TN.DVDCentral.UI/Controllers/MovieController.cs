
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TN.DVDCentral.BL.Models;
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

                HttpContext.Session.SetObject("movieid", movieVM.MovieId);

                return View(movieVM);
            }
            else return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            
        }

        [HttpPost]
        public IActionResult Create(MovieVM movieVM, int id, bool rollback = false)
        {
            try
            {
                

                IEnumerable<int> newGenreIds = new List<int>();
                if (movieVM.GenreIds != null)
                {
                    newGenreIds = movieVM.GenreIds;
                    movieVM.MovieId = GetObject();
                    IEnumerable<int> adds = newGenreIds;
                    newGenreIds = GetObject();
                    adds.ToList().ForEach(a => MovieGenreManager.Insert(id, a));

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

                    int result = MovieManager.Insert(movieVM.Movie, rollback); 
                    return RedirectToAction(nameof(Index));
            }
                else
            {
                throw new Exception("genreids is null");
            }
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

                MovieVM movieVM = new MovieVM(id);

                ViewBag.Title = "Edit " + movieVM.Movie.Title;
                HttpContext.Session.SetObject("genreids", movieVM.GenreIds);
                //HttpContext.Session.SetObject("ratingids", movieVM.RatingIds);
                //HttpContext.Session.SetObject("directorids", movieVM.DirectorIds);
                //HttpContext.Session.SetObject("formatids", movieVM.FormatIds);
                return View(movieVM);                
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
                IEnumerable<int> newGenreIds = new List<int>();
                if (movieVM.GenreIds != null)
                {
                    newGenreIds = movieVM.GenreIds;

                    IEnumerable<int> oldGenreIds = new List<int>();
                    oldGenreIds = GetObject();

                    IEnumerable<int> deletes = oldGenreIds.Except(newGenreIds);
                    IEnumerable<int> adds = newGenreIds.Except(oldGenreIds);

                    deletes.ToList().ForEach(d => MovieGenreManager.Delete(id, d));
                    adds.ToList().ForEach(a => MovieGenreManager.Insert(id, a));
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
                else
                {
                    throw new Exception("genreids is null");
                }
                

            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit " + movieVM.Movie.Title;
                ViewBag.Error = ex.Message;
                return View(movieVM);
            }
        }

        private IEnumerable<int> GetObject()
        {
            if(HttpContext.Session.GetObject<IEnumerable<int>>("genreids") != null)
            {
                return HttpContext.Session.GetObject<IEnumerable<int>>("genreids");
            }
            else
            {
                return null;
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
                ViewBag.Title = "Delete " + movie.Title;
                ViewBag.Error = ex.Message;
                return View(movie);
            }

        }
    }
}
