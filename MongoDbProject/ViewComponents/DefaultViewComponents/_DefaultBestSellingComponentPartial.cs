using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultBestSellingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
