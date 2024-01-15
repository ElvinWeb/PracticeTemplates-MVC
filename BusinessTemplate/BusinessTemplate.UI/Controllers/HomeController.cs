using BusinessTemplate.Business.Services.Service;
using BusinessTemplate.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BusinessTemplate.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _blogService.GetAllAsync();

            return View(blogs);
        }


    }
}