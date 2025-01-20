using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
