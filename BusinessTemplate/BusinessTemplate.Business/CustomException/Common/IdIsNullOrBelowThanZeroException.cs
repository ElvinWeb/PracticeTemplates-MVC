using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.CustomException.Common
{
    public class IdIsNullOrBelowThanZeroException : Exception
    {

        public string PropertyName { get; set; }
        public IdIsNullOrBelowThanZeroException()
        {
        }

        public IdIsNullOrBelowThanZeroException(string? message) : base(message)
        {
        }

        public IdIsNullOrBelowThanZeroException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
