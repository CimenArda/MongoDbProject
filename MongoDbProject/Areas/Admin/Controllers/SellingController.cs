using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDbProject.Dtos.SellingDtos;
using MongoDbProject.Entities;
using MongoDbProject.Services.ProductServices;
using MongoDbProject.Services.SellingServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Selling/")]
	public class SellingController : Controller
	{
		private readonly ISellingService _sellingService;
		private readonly IProductService _productService;
		public SellingController(ISellingService sellingService, IProductService productService)
		{
			_sellingService = sellingService;
			_productService = productService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var values = await _sellingService.GetAllSellingAsync();
			return View(values);
		}

		[HttpGet]
		[Route("CreateSelling")]
		public async Task<IActionResult> CreateSelling()
		{
			var values = await _productService.GetAllProductAsync();
			List<SelectListItem> productvalues = (from x in values
												   select new SelectListItem
												   {
													   Text = x.ProductName,
													   Value = x.ProductID
												   }).ToList();
			ViewBag.productvalues = productvalues;

			return View();

		}


		[HttpPost]
		[Route("CreateSelling")]
		public async Task<IActionResult> CreateSelling(CreateSellingDto createSellingDto)
		{
			createSellingDto.TotalPrice = createSellingDto.Count * createSellingDto.Price;
			await _sellingService.CreateSellingAsync(createSellingDto);
			return RedirectToAction("Index");

		}



	}
}
