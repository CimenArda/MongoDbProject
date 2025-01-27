using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
