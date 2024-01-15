using BusinessTemplate.Business.CustomException.Blog;
using BusinessTemplate.Business.CustomException.Common;
using BusinessTemplate.Business.Helpers;
using BusinessTemplate.Business.Services.Service;
using BusinessTemplate.Core.Entities;
using BusinessTemplate.Core.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IWebHostEnvironment _env;

        public BlogService(IBlogRepository blogRepository, IWebHostEnvironment env)
        {
            _blogRepository = blogRepository;
            _env = env;
        }
        public async Task CreateAsync(Blog blog)
        {
            if (blog.Image != null)
            {
                if (blog.Image.ContentType != "image/png" && blog.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidContentTypeOrImageSizeException("Image", "image content type is wrong!");
                }


                if (blog.Image.Length > 1048576)
                {
                    throw new InvalidContentTypeOrImageSizeException("Image", "file size should be more lower than 1mb");
                }
            }
            else
            {
                throw new ImageRequiredException("Image", "Image is required!");
            }

            string folder = "uploads/blogs-images";
            string newFilePath = await Helper.GetFileName(_env.WebRootPath, folder, blog.Image);
            blog.ImgUrl = newFilePath;

            await _blogRepository.CreateAsync(blog);
            await _blogRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null && id <= 0) throw new IdIsNullOrBelowThanZeroException("id cannot be null or less than zero");

            Blog blog = await _blogRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);

            if (blog == null) throw new BlogNullReferenceException("blog is null here!");

            string fullPath = Path.Combine(_env.WebRootPath, "uploads/bg-slide", blog.ImgUrl);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            _blogRepository.Delete(blog);
            await _blogRepository.CommitAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task SoftDelete(int id)
        {
            if (id == null && id <= 0) throw new IdIsNullOrBelowThanZeroException("id cannot be null or less than zero");

            Blog blog = await _blogRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);

            if (blog == null) throw new BlogNullReferenceException("blog is null here!");

            blog.IsDeleted = !blog.IsDeleted;
            await _blogRepository.CommitAsync();
        }

        public async Task UpdateAsync(Blog blog)
        {
            Blog wantedBlog = await _blogRepository.GetByIdAsync(x => x.Id == blog.Id && !x.IsDeleted);

            if (wantedBlog == null) throw new BlogNullReferenceException("blog is null here!");

            if (blog.Image != null)
            {
                if (blog.Image.ContentType != "image/png" && blog.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidContentTypeOrImageSizeException("Image", "image content type is wrong!");
                }


                if (blog.Image.Length > 1048576)
                {
                    throw new InvalidContentTypeOrImageSizeException("Image", "file size should be more lower than 1mb");
                }

                string folder = "uploads/blogs-images";
                string oldFilePath = Path.Combine(_env.WebRootPath, folder, wantedBlog.ImgUrl);
                string updatedFilePath = await Helper.GetFileName(_env.WebRootPath, folder, blog.Image);

                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
                blog.ImgUrl = updatedFilePath;

            }

            wantedBlog.Title = blog.Title;
            wantedBlog.Description = blog.Description;

            await _blogRepository.CommitAsync();
        }
    }
}
