using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.CustomException.Common
{
    public class InvalidContentTypeOrImageSizeException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidContentTypeOrImageSizeException()
        {
        }

        public InvalidContentTypeOrImageSizeException(string? message) : base(message)
        {
        }

        public InvalidContentTypeOrImageSizeException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
