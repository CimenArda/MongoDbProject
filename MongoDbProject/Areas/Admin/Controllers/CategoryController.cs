using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.CategoryDtos;
using MongoDbProject.Services.CategoryServices;

namespace MongoDbProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Category/")]
	public class CategoryController : Controller
	{

		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var value = await _categoryService.GetAllCategoryAsync();
			return View(value);
		}

		[HttpGet]
		[Route("CreateCategory")]
		public async Task<IActionResult> CreateCategory()
		{
			return View();

		}


		[HttpPost]
		[Route("CreateCategory")]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			_categoryService.CreateCategoryAsync(createCategoryDto);
			return RedirectToAction("Index");	

		}

		[Route("DeleteCategory/{id}")]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			_categoryService.DeleteCategoryAsync(id);
           return RedirectToAction("Index");


		}

		[Route("UpdateCategory/{id}")]
		public async Task<IActionResult> UpdateCategory(string id)
		{
			var category = await _categoryService.GetByIdCategoryAsync(id);
			return View(category);
		}

		[Route("UpdateCategory/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			await _categoryService.UpdateCategoryAsync(updateCategoryDto);
			return RedirectToAction("Index");

		}





	}
}
