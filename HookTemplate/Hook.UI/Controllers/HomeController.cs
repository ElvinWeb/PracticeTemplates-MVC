using Hook.Business.Services.Service;
using Hook.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hook.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureService _featureService;

        public HomeController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IActionResult> Index()
        {
            List<Feature> features = await _featureService.GetAllFeatureAsync(); 

            return View(features);
        }

        
    }
}