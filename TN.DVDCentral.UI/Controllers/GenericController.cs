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
    }
}
