namespace TN.DVDCentral.UI.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        dynamic manager;
        private ApiClient apiClient;
        public GenericController(HttpClient httpClient)
        {
            this.apiClient = new ApiClient(httpClient.BaseAddress.AbsoluteUri);
            manager= (T)Activator.CreateInstance(typeof(T));
        }
        public virtual IActionResult Index()
        {
            ViewBag.Title = "List of " + typeof(T).Name + "s";
            
            var entities = apiClient.GetList<T>(typeof(T).Name);
            return View(entities);
        }

        public IActionResult Details(Guid id)
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodname + " for " + typeof(T).Name;
            var entity = apiClient.GetItem<T>(typeof (T).Name, id);
            return View(entity);
        }

        public virtual IActionResult Create()
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodname + " for " + typeof(T).Name;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(T entity, bool rollback = false)
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                ViewBag.Title = methodname + " for " + typeof(T).Name;
                var response = apiClient.Post<T>(entity, typeof(T).Name);
                var result = response.Content.ReadAsStringAsync().Result;
                //TODO Get the id
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = methodname + " for " + typeof(T).Name;
                ViewBag.Error = ex.Message;
                return View(entity);
            }

        }

        public IActionResult Edit(Guid id)
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodname + " for " + typeof(T).Name;
            var entity = apiClient.GetItem<T>(typeof(T).Name, id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Guid id, T entity, bool rollback = false)
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                ViewBag.Title = methodname + " for " + typeof(T).Name;
                var response = apiClient.Put<T>(entity, typeof(T).Name, id);
                var result = response.Content.ReadAsStringAsync().Result;
                //TODO Get the id
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = methodname + " for " + typeof(T).Name;
                ViewBag.Error = ex.Message;
                return View(entity);
            }

        }

        public virtual IActionResult Delete(Guid id)
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodname + " for " + typeof(T).Name;
            var entity = apiClient.GetItem<T>(typeof(T).Name, id);
            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Delete(Guid id, T entity, bool rollback = false)
        {
            string methodname = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                ViewBag.Title = methodname + " for " + typeof(T).Name;
                var response = apiClient.Delete(typeof(T).Name, id);
                var result = response.Content.ReadAsStringAsync().Result;
                //TODO Get the id
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = methodname + " for " + typeof(T).Name;
                ViewBag.Error = ex.Message;
                return View(entity);
            }

        }

    }
}
