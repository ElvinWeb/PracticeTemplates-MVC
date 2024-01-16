using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Core.Entities
{
    public class User : IdentityUser
    {
        [StringLength(maximumLength: 30)]
        public string FullName { get; set; }
    }
}
