using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutTopCategoryListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
