using Hook.Business.CustomExceptions.General;
using Hook.Business.Services.Service;
using Hook.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hook.UI.areas.manage.Controllers
{
    [Area("manage")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IActionResult> Index()
        {
            List<Feature> features = await _featureService.GetAllFeatureAsync();

            return View(features);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Feature feature)
        {
            if(!ModelState.IsValid) return View(feature);

            await _featureService.CreateAsync(feature);

            return RedirectToAction("index", "Feature");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Feature feature = await _featureService.GetFeatureAsync(id);
            if (feature == null) return View();

            return View(feature);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Feature feature)
        {
            if (!ModelState.IsValid) return View(feature);

            try
            {
                await _featureService.UpdateAsync(feature);

            }
            catch (EntityNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View("error");
            }
            catch (InvalidIdOrBelowThanZero ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View("error");
            }

            return RedirectToAction("index", "feature");
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _featureService.SoftDelete(id);

            }
            catch (EntityNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View("error");
            }
            catch (InvalidIdOrBelowThanZero ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View("error");
            }

            return Ok();
        }
    }
}
