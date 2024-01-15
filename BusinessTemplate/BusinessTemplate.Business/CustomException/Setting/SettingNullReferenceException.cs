using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.CustomException.Setting
{
    public class SettingNullReferenceException : Exception
    {
        public string PropertyName { get; set; }
        public SettingNullReferenceException()
        {
        }

        public SettingNullReferenceException(string? message) : base(message)
        {
        }

        public SettingNullReferenceException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
