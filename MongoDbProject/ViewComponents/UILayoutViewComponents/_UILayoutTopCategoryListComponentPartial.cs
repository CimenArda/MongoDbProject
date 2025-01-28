using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Services.CategoryServices;

namespace MongoDbProject.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutTopCategoryListComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _UILayoutTopCategoryListComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
