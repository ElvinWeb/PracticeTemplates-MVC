using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.CustomException.User
{
    public class InvalidUserCredential : Exception
    {
        public string PropertyName { get; set; }
        public InvalidUserCredential()
        {
        }

        public InvalidUserCredential(string? message) : base(message)
        {
        }

        public InvalidUserCredential(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
