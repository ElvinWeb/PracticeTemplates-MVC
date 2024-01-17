using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.ViewModels
{
    public class AdminLoginViewModel
    {
        [StringLength(maximumLength: 15, MinimumLength = 5)]
        [Required]
        public string UserName { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }
    }
}
