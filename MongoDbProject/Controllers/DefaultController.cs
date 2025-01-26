using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
