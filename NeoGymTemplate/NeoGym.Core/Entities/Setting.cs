using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Core.Entities
{
    public class Setting : BaseEntity
    {
        [StringLength(maximumLength: 15, MinimumLength = 5)]
        [Required]
        public string? Key { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        [Required]
        public string Value { get; set; }
    }
}
