using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.FeatureDtos;
using MongoDbProject.Services.FeatureServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Feature/")]
	public class FeatureController : Controller
	{
		private readonly IFeatureService _FeatureService;

		public FeatureController(IFeatureService FeatureService)
		{
			_FeatureService = FeatureService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var value = await _FeatureService.GetAllFeatureAsync();
			return View(value);
		}

		[HttpGet]
		[Route("CreateFeature")]
		public async Task<IActionResult> CreateFeature()
		{
			return View();

		}


		[HttpPost]
		[Route("CreateFeature")]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			_FeatureService.CreateFeatureAsync(createFeatureDto);
			return RedirectToAction("Index");

		}

		[Route("DeleteFeature/{id}")]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			_FeatureService.DeleteFeatureAsync(id);
			return RedirectToAction("Index");


		}

		[Route("UpdateFeature/{id}")]
		public async Task<IActionResult> UpdateFeature(string id)
		{
			var Feature = await _FeatureService.GetByIdFeatureAsync(id);
			return View(Feature);
		}

		[Route("UpdateFeature/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _FeatureService.UpdateFeatureAsync(updateFeatureDto);
			return RedirectToAction("Index");

		}


	}
}
