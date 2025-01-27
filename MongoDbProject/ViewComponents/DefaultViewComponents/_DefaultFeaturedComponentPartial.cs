using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeaturedComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
