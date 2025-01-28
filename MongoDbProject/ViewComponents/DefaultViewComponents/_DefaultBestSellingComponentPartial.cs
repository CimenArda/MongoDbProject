using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Services.SellingServices;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultBestSellingComponentPartial : ViewComponent
    {
        private readonly ISellingService _sellingService;

        public _DefaultBestSellingComponentPartial(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sellingService.GetTop8SellingProductsAsync();
            return View(values);
        }
    }
}
