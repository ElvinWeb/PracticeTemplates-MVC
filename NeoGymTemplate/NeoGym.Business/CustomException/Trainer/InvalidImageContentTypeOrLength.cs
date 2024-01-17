using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.CustomException.Trainer
{
    public class InvalidImageContentTypeOrLength : Exception
    {
        public string PropertyName { get; set; }
        public InvalidImageContentTypeOrLength()
        {
        }

        public InvalidImageContentTypeOrLength(string? message) : base(message)
        {
        }

        public InvalidImageContentTypeOrLength(string propName , string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
