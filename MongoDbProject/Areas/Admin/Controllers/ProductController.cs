using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Services.CategoryServices;
using MongoDbProject.Services.ProductServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Product/")]
	public class ProductController : Controller
	{
		private readonly IProductService _ProductService;
		private readonly ICategoryService _CategoryService;
        public ProductController(IProductService ProductService, ICategoryService categoryService)
        {
            _ProductService = ProductService;
            _CategoryService = categoryService;
        }

        [Route("Index")]
		public async Task<IActionResult> Index()
		{
			var value = await _ProductService.GetAllProductWithCategoryAsync();
			return View(value);
		}

		[HttpGet]
		[Route("CreateProduct")]
		public async Task<IActionResult> CreateProduct()
		{
			var category = await _CategoryService.GetAllCategoryAsync();
			List<SelectListItem> categoryValues = (from x in category
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID
												   }).ToList();
            ViewBag.categoryValues = categoryValues;

            return View();

		}


		[HttpPost]
		[Route("CreateProduct")]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _ProductService.CreateProductAsync(createProductDto);
			return RedirectToAction("Index");

		}

		[Route("DeleteProduct/{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await	_ProductService.DeleteProductAsync(id);
			return RedirectToAction("Index");


		}

		[Route("UpdateProduct/{id}")]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			var category = await _CategoryService.GetAllCategoryAsync();
			List<SelectListItem> categoryValues = (from x in category
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID
												   }).ToList();
			ViewBag.categoryValues = categoryValues;
			var Product = await _ProductService.GetByIdProductAsync(id);
			return View(Product);
		}

		[Route("UpdateProduct/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			await _ProductService.UpdateProductAsync(updateProductDto);
			return RedirectToAction("Index");

		}


	}
}
