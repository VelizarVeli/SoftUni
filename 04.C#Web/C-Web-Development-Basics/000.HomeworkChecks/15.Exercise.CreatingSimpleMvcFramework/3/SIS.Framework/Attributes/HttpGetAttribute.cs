using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Attributes
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "GET")
            {
                return true;
            }

            return false;
        }
    }
}
