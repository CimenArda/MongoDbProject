using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Services.DiscountServices;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultTopDiscountComponentPartial : ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _DefaultTopDiscountComponentPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _discountService.GetAllDiscountAsync();
            return View(values);
        }
    }
}
