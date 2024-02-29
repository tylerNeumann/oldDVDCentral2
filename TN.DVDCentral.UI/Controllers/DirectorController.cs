namespace TN.DVDCentral.UI.Controllers
{
    public class DirectorController : GenericController<Director>
    {
        public DirectorController(HttpClient httpClient) : base(httpClient) { }
        //        private readonly IWebHostEnvironment _host;
        //        public DirectorController(IWebHostEnvironment host)
        //        {
        //            _host = host;
        //        }
        //        #region "Pre-WebAPI
        //        public IActionResult Index()
        //        {
        //            ViewBag.Title = "List of Directors";
        //            return View(DirectorManager.Load());
        //        }

        //        public IActionResult Details(int id) 
        //        { 
        //            var item = DirectorManager.LoadById(id);
        //            ViewBag.Title = "Director Details";
        //            return View(item);
        //        }

        //        public IActionResult Create() 
        //        {
        //            if (Authentication.IsAuthenticated(HttpContext))
        //            {
        //                ViewBag.Title = "Create a director";
        //                return View();
        //            }

        //            else
        //            {
        //                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        //            }
        //        }

        //        [HttpPost]
        //        public IActionResult Create(Director director) 
        //        {
        //            try
        //            {
        //                int result = DirectorManager.Insert(director);
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }

        //        }

        //        public IActionResult Edit(int id) 
        //        {
        //            if (Authentication.IsAuthenticated(HttpContext))
        //            {
        //                var item = DirectorManager.LoadById(id);
        //                ViewBag.Title = "Edit a director";
        //                return View(item);
        //            }

        //            else
        //            {
        //                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        //            }
        //        }
        //        [HttpPost]
        //        public IActionResult Edit(int id, Director director, bool rollback = false) 
        //        {
        //            try
        //            {
        //                int result = DirectorManager.Insert(director, rollback);
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch (Exception ex)
        //            {
        //                ViewBag.Error = ex.Message;
        //                return View(director);
        //            }

        //        }

        //        public IActionResult Delete(int id) 
        //        {
        //            if (Authentication.IsAuthenticated(HttpContext))
        //            {
        //                var item = DirectorManager.LoadById(id);
        //                ViewBag.Title = "Delete a director";
        //                return View(item);
        //            }

        //            else
        //            {
        //                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
        //            }
        //        }
        //        [HttpPost]
        //        public IActionResult Delete(int id, Director director, bool rollback = false) 
        //        {
        //            try
        //            {
        //                int result = DirectorManager.Delete(id, rollback);
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch (Exception ex)
        //            {
        //                ViewBag.Error = ex.Message;
        //                return View(director);
        //            }

        //        }
        //#endregion
        //        #region "Web-API"

        //        private static HttpClient InitializeClient()
        //        {
        //            HttpClient client = new HttpClient();
        //            client.BaseAddress = new Uri("https://localhost:7269/api/");
        //            return client;
        //        }

        //        public IActionResult Get()
        //        {
        //            HttpClient client = InitializeClient();
        //            //call the API
        //            HttpResponseMessage response = client.GetAsync("Director").Result;

        //            //parse the result
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
        //            List<BL.Models.Director> director = items.ToObject<List<BL.Models.Director>>();

        //            return View(nameof(Index), director);

        //        }
        //        public IActionResult GetOne(int id)
        //        {
        //            HttpClient client = InitializeClient();
        //            //call api
        //            HttpResponseMessage response = client.GetAsync("Director/" + id).Result;


        //            //parse the result
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            dynamic item = (JArray)JsonConvert.DeserializeObject(result);
        //            BL.Models.Director director = item.ToObject<List<BL.Models.Director>>();

        //            return View(nameof(Details), director);
        //        }

        //        public IActionResult Insert()
        //        {
        //            HttpClient client = InitializeClient();
        //            //call the api
        //            HttpResponseMessage response = client.GetAsync("Director").Result;

        //            //parse the result
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
        //            List<Director> directors = items.ToObject<List<Director>>();

        //            Director director = new Director();



        //            return View(nameof(Create), director);
        //        }

        //        [HttpPost]
        //        public IActionResult Insert(Director director)
        //        {
        //            try
        //            {
        //                HttpClient client = InitializeClient();


        //                string serializedObject = JsonConvert.SerializeObject(director);
        //                var content = new StringContent(serializedObject);
        //                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //                //call the API
        //                HttpResponseMessage response = client.PostAsync("Director", content).Result;
        //                return RedirectToAction(nameof(Get));
        //            }
        //            catch (Exception ex)
        //            {
        //                ViewBag.Error = ex.Message;
        //                return View(nameof(Create), director);
        //            }
        //        }
        //        public IActionResult Update(int id)
        //        {
        //            HttpClient client = InitializeClient();

        //            //call api
        //            HttpResponseMessage response = client.GetAsync("Director/" + id).Result;

        //            //parse the result
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            dynamic item = (JArray)JsonConvert.DeserializeObject(result);
        //            BL.Models.Director director = item.ToObject<List<BL.Models.Director>>();

        //            //Director director = new Director();

        //            return View(nameof(Edit), director);
        //        }
        //        [HttpPost]
        //        public IActionResult Update(int id, Director director)
        //        {
        //            try
        //            {
        //                HttpClient client = InitializeClient();

        //                string serializedObject = JsonConvert.SerializeObject(director);
        //                var content = new StringContent(serializedObject);
        //                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //                //call the API
        //                HttpResponseMessage response = client.PutAsync("Director/" + id, content).Result;
        //                return RedirectToAction(nameof(Get));
        //            }
        //            catch (Exception ex)
        //            {
        //                ViewBag.Error = ex.Message;
        //                return View(nameof(Edit), director);
        //            }
        //        }
        //        public IActionResult Remove(int id)
        //        {
        //            HttpClient client = InitializeClient();

        //            //call api
        //            HttpResponseMessage response = client.GetAsync("Director/" + id).Result;

        //            //parse the result
        //            string result = response.Content.ReadAsStringAsync().Result;
        //            dynamic item = (JArray)JsonConvert.DeserializeObject(result);
        //            BL.Models.Director director = item.ToObject<List<BL.Models.Director>>();

        //            return View(nameof(Delete), director);
        //        }
        //        [HttpPost]
        //        public IActionResult Remove(int id, BL.Models.Director director)
        //        {
        //            try
        //            {
        //                HttpClient client = InitializeClient();
        //                HttpResponseMessage response = client.DeleteAsync("Director/" + id).Result;
        //                return View(nameof(Get), director);
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }
        //        }

        //        #endregion
    }
}
