using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Core.Entities
{
    public class Trainer : BaseEntity
    {
        [StringLength(maximumLength: 30, MinimumLength = 10)]
        [Required]
        public string FullName { get; set; }
        [StringLength(maximumLength: 60, MinimumLength = 20)]
        [Required]
        public string TwitterUrl { get; set; }
        [StringLength(maximumLength: 60, MinimumLength = 20)]
        [Required]
        public string FacebookUrl { get; set; }
        [StringLength(maximumLength: 60, MinimumLength = 20)]
        [Required]
        public string InstagramUrl { get; set; }
        [StringLength(maximumLength: 100)]
        public string? ImgUrl { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Image { get; set; }
    }
}
