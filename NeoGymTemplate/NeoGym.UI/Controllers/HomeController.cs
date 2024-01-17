using Microsoft.AspNetCore.Mvc;
using NeoGym.Business.Services.Service;
using NeoGym.Core.Entities;
using System.Diagnostics;

namespace NeoGym.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrainerService _trainerService;

        public HomeController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public async Task<IActionResult> Index()
        {
            List<Trainer> trainers = await _trainerService.GetAllTrainerAsync();

            return View(trainers);
        }

    }
}