using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Services.CategoryServices;
using MongoDbProject.Services.ProductServices;

namespace MongoDbProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
          
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllProductWithCategoryAsync();
            return View(values);
        }


        public async Task<IActionResult> GetProducstByCategoryID(string id)
        {
            var values = await _productService.GetAllProductWithCategoryByCategoryIdAsync(id);
            
            return View(values);
        }
    }
}
