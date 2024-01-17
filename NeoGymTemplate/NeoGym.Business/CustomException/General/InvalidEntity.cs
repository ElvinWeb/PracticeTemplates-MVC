using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.CustomException.General
{
    public class InvalidEntity : Exception
    {
        public string PropertyName { get; set; }
        public InvalidEntity()
        {
        }

        public InvalidEntity(string? message) : base(message)
        {
        }

        public InvalidEntity(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
