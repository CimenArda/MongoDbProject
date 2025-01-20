using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
