using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Core.Entities
{
    public class Feature : BaseEntity
    {
        [StringLength(maximumLength: 30)]
        public string Title { get; set; }
        [StringLength(maximumLength: 150)]
        public string Description { get; set; }
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }
    }
}
