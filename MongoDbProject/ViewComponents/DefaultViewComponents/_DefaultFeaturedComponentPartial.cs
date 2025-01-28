using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Services.FeatureServices;

namespace MongoDbProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeaturedComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultFeaturedComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
