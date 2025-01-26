using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}