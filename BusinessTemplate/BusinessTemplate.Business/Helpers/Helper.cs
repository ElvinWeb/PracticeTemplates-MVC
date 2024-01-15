using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.Helpers
{
    public static class Helper
    {
        public static async Task<string> GetFileName(string webRootPath, string folder, IFormFile formFile)
        {
            string fileName = formFile.FileName.Length > 64 ? formFile.FileName.Substring(formFile.FileName.Length - 64, 64) : formFile.FileName;
            fileName = Guid.NewGuid().ToString() + formFile.FileName;
            string filePath = Path.Combine(webRootPath, folder, fileName);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
