﻿using System.Collections.Generic;
using SIS.Framework.Attributes;
using SIS.Framework.Attributes.Property;

namespace IRunesWebApp
{
    public class IndexViewModel
    {
        [NumberRange(5, 12)]
        public double Id { get; set; }

        [Regex(@"^[a-zA-Z]+$")]
        public string Username { get; set; }
    }
}