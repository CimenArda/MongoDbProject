using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.DiscountDtos;
using MongoDbProject.Services.DiscountServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Discount/")]
	public class DiscountController : Controller
	{

		private readonly IDiscountService _DiscountService;

		public DiscountController(IDiscountService DiscountService)
		{
			_DiscountService = DiscountService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var value = await _DiscountService.GetAllDiscountAsync();
			return View(value);
		}

		[HttpGet]
		[Route("CreateDiscount")]
		public async Task<IActionResult> CreateDiscount()
		{
			return View();

		}


		[HttpPost]
		[Route("CreateDiscount")]
		public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
		{
		await _DiscountService.CreateDiscountAsync(createDiscountDto);
			return RedirectToAction("Index");

		}

		[Route("DeleteDiscount/{id}")]
		public async Task<IActionResult> DeleteDiscount(string id)
		{
			await _DiscountService.DeleteDiscountAsync(id);
			return RedirectToAction("Index");


		}

		[Route("UpdateDiscount/{id}")]
		public async Task<IActionResult> UpdateDiscount(string id)
		{
			var Discount = await _DiscountService.GetByIdDiscountAsync(id);
			return View(Discount);
		}

		[Route("UpdateDiscount/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			await _DiscountService.UpdateDiscountAsync(updateDiscountDto);
			return RedirectToAction("Index");

		}




	}
}
