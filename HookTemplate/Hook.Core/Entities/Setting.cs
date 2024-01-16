using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Core.Entities
{
    public class Setting : BaseEntity
    {

        public string? Key { get; set; }
        [StringLength(maximumLength: 150)]
        public string Value { get; set; }
    }
}
