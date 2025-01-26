using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutTopbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
