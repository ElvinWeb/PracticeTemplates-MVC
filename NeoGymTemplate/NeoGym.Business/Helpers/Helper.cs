using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.Helpers
{
    public static class Helper
    {
        public static async Task<string> GetFileName(string webRootPath, string folder, IFormFile image)
        {
            string fileName = image.FileName.Length > 64 ? image.FileName.Substring(image.FileName.Length - 64, 64) : image.FileName;
            fileName = Guid.NewGuid().ToString() + image.FileName;

            string filePath = Path.Combine(webRootPath, folder, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
