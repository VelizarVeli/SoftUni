using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Attributes.Methods.Base
{
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
