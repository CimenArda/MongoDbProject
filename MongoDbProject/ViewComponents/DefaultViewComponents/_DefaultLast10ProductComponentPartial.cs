using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Services.ProductServices;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast10ProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultLast10ProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetLast10ProductWithCategoryAsync();
            return View(values);
        }
    }
}
