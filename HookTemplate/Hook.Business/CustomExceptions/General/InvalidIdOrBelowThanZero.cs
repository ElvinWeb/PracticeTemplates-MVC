using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.CustomExceptions.General
{
    public class InvalidIdOrBelowThanZero : Exception
    {

        public string PropertyName { get; set; }
        public InvalidIdOrBelowThanZero()
        {
        }

        public InvalidIdOrBelowThanZero(string? message) : base(message)
        {

        }

        public InvalidIdOrBelowThanZero(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }

    }
}
