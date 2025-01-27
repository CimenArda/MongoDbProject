using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultServicesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
