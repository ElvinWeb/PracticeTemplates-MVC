using BusinessTemplate.Business.CustomException.Blog;
using BusinessTemplate.Business.CustomException.Common;
using BusinessTemplate.Business.CustomException.Image;
using BusinessTemplate.Business.Services.Service;
using BusinessTemplate.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTemplate.UI.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _blogService.GetAllAsync();

            return View(blogs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid) return View(blog);

            try
            {
                await _blogService.CreateAsync(blog);
            }
            catch (ImageRequiredException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidContentTypeOrImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "blog");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _blogService.GetByIdAsync(id);

            if (blog == null) throw new BlogNullReferenceException("blog is null here!");

            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Blog blog)
        {

            if (!ModelState.IsValid) return View(blog);

            try
            {
                await _blogService.UpdateAsync(blog);
            }
            catch (BlogNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidContentTypeOrImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "blog");
        }

        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _blogService.SoftDelete(id);
            }
            catch (IdIsNullOrBelowThanZeroException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (BlogNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }


            return Ok();
        }
    }
}
