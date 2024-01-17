using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.CustomException.Trainer
{
    public class ImageRequired : Exception
    {
        public string PropertyName { get; set; }
        public ImageRequired()
        {
        }

        public ImageRequired(string? message) : base(message)
        {
        }

        public ImageRequired(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
