using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast10ProductComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
