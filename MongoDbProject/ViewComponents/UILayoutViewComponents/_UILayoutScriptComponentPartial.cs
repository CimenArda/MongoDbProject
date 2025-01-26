using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
