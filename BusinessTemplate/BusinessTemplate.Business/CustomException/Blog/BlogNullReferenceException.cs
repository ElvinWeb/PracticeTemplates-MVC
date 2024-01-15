using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.CustomException.Blog
{
    public class BlogNullReferenceException : Exception
    {
        public string PropertyName { get; set; }
        public BlogNullReferenceException()
        {
        }

        public BlogNullReferenceException(string? message) : base(message)
        {
        }

        public BlogNullReferenceException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
