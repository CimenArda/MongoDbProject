using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutHeadComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
