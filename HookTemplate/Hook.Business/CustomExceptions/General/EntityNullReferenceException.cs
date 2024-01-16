using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.CustomExceptions.General
{
    public class EntityNullReferenceException : Exception
    {
        public string PropertyName { get; set; }
        public EntityNullReferenceException()
        {
        }

        public EntityNullReferenceException(string? message) : base(message)
        {

        }

        public EntityNullReferenceException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }


    }
}
