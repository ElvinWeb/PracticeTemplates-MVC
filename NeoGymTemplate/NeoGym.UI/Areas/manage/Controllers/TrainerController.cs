using Microsoft.AspNetCore.Mvc;
using NeoGym.Business.CustomException.General;
using NeoGym.Business.CustomException.Trainer;
using NeoGym.Business.Services.Implementations;
using NeoGym.Business.Services.Service;
using NeoGym.Core.Entities;
using NuGet.Protocol;

namespace NeoGym.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public async Task<IActionResult> Index()
        {
            List<Trainer> trainers = await _trainerService.GetAllTrainerAsync();

            return View(trainers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _trainerService.CreateAsync(trainer);
            }
            catch (InvalidImageContentTypeOrLength ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ImageRequired ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }


            return RedirectToAction("index", "trainer");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == null && id <= 0) return NotFound("id coludn't be null or negative");

            Trainer trainer = await _trainerService.GetTrainerByIdAsync(id);

            return View(trainer);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Trainer trainer)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _trainerService.UpdateAsync(trainer);
            }
            catch (InvalidImageContentTypeOrLength ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidEntity ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "trainer");
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _trainerService.SoftDelete(id);
            }
            catch (InvalidIdOrBelowThanZero ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }


            return Ok();
        }
    }
}
