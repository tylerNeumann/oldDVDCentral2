using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TN.DVDCentral.BL;
using TN.DVDCentral.BL.Models;
using TN.DVDCentral.PL2.Data;

namespace TN.WebApp.UI.Controllers
{
   
    public class DirectorController : Controller
    {
        private readonly DbContextOptions<DVDCentralEntities> options;
        private readonly IWebHostEnvironment _host;
        public DirectorController(IWebHostEnvironment host)
        {
            _host = host;
        }
        #region "Pre-WebAPI
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.Title = "List of Directors";
            ViewBag.Info = TempData["info"];
            return View(new DirectorManager(options).Load());
        }
        
        public IActionResult Details(Guid id)
        { 
            var item = new DirectorManager(options).LoadById(id);
            ViewBag.Title = "Director Details";
            return View(item);
        }
        [Authorize]
        public IActionResult Create() 
        {
                ViewBag.Title = "Create a director";
                return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Director director) 
        {
            try
            {
                int result = new DirectorManager(options).Insert(director);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public IActionResult Edit(Guid id) 
        {
                var item = new DirectorManager(options).LoadById(id);
                ViewBag.Title = "Edit a director";
                return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Guid id, Director director, bool rollback = false) 
        {
            try
            {
                int result = new DirectorManager(options).Insert(director, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
            
        }

        public IActionResult Delete(Guid id) 
        {
                var item = new DirectorManager(options).LoadById(id);
                ViewBag.Title = "Delete a director";
                return View(item);
        }
        [HttpPost]
        public IActionResult Delete(Guid id, Director director, bool rollback = false) 
        {
            try
            {
                int result = new DirectorManager(options).Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
            
        }
#endregion
    //    #region "Web-API"

    //    private static HttpClient InitializeClient()
    //    {
    //        HttpClient client = new HttpClient();
    //        client.BaseAddress = new Uri("https://localhost:7269/api/");
    //        return client;
    //    }

    //    public IActionResult Get()
    //    {
    //        HttpClient client = InitializeClient();
    //        //call the API
    //        HttpResponseMessage response = client.GetAsync("Director").Result;

    //        //parse the result
    //        string result = response.Content.ReadAsStringAsync().Result;
    //        dynamic items = (JArray)JsonConvert.DeserializeObject(result);
    //        List<BL.Models.Director> director = items.ToObject<List<BL.Models.Director>>();

    //        return View(nameof(Index), director);

    //    }
    //    public IActionResult GetOne(int id)
    //    {
    //        HttpClient client = InitializeClient();
    //        //call api
    //        HttpResponseMessage response = client.GetAsync("Director/" + id).Result;


    //        //parse the result
    //        string result = response.Content.ReadAsStringAsync().Result;
    //        dynamic item = (JArray)JsonConvert.DeserializeObject(result);
    //        BL.Models.Director director = item.ToObject<List<BL.Models.Director>>();

    //        return View(nameof(Details), director);
    //    }

    //    public IActionResult Insert()
    //    {
    //        HttpClient client = InitializeClient();
    //        //call the api
    //        HttpResponseMessage response = client.GetAsync("Director").Result;

    //        //parse the result
    //        string result = response.Content.ReadAsStringAsync().Result;
    //        dynamic items = (JArray)JsonConvert.DeserializeObject(result);
    //        List<Director> directors = items.ToObject<List<Director>>();

    //        Director director = new Director();
            
            

    //        return View(nameof(Create), director);
    //    }

    //    [HttpPost]
    //    public IActionResult Insert(Director director)
    //    {
    //        try
    //        {
    //            HttpClient client = InitializeClient();
                

    //            string serializedObject = JsonConvert.SerializeObject(director);
    //            var content = new StringContent(serializedObject);
    //            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

    //            //call the API
    //            HttpResponseMessage response = client.PostAsync("Director", content).Result;
    //            return RedirectToAction(nameof(Get));
    //        }
    //        catch (Exception ex)
    //        {
    //            ViewBag.Error = ex.Message;
    //            return View(nameof(Create), director);
    //        }
    //    }
    //    public IActionResult Update(int id)
    //    {
    //        HttpClient client = InitializeClient();

    //        //call api
    //        HttpResponseMessage response = client.GetAsync("Director/" + id).Result;

    //        //parse the result
    //        string result = response.Content.ReadAsStringAsync().Result;
    //        dynamic item = (JArray)JsonConvert.DeserializeObject(result);
    //        BL.Models.Director director = item.ToObject<List<BL.Models.Director>>();

    //        //Director director = new Director();

    //        return View(nameof(Edit), director);
    //    }
    //    [HttpPost]
    //    public IActionResult Update(int id, Director director)
    //    {
    //        try
    //        {
    //            HttpClient client = InitializeClient();

    //            string serializedObject = JsonConvert.SerializeObject(director);
    //            var content = new StringContent(serializedObject);
    //            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

    //            //call the API
    //            HttpResponseMessage response = client.PutAsync("Director/" + id, content).Result;
    //            return RedirectToAction(nameof(Get));
    //        }
    //        catch (Exception ex)
    //        {
    //            ViewBag.Error = ex.Message;
    //            return View(nameof(Edit), director);
    //        }
    //    }
    //    public IActionResult Remove(int id)
    //    {
    //        HttpClient client = InitializeClient();

    //        //call api
    //        HttpResponseMessage response = client.GetAsync("Director/" + id).Result;

    //        //parse the result
    //        string result = response.Content.ReadAsStringAsync().Result;
    //        dynamic item = (JArray)JsonConvert.DeserializeObject(result);
    //        BL.Models.Director director = item.ToObject<List<BL.Models.Director>>();

    //        return View(nameof(Delete), director);
    //    }
    //    [HttpPost]
    //    public IActionResult Remove(int id, BL.Models.Director director)
    //    {
    //        try
    //        {
    //            HttpClient client = InitializeClient();
    //            HttpResponseMessage response = client.DeleteAsync("Director/" + id).Result;
    //            return View(nameof(Get), director);
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    #endregion
    }
}
