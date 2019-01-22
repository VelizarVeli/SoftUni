using SIS.Framework.Attributes.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Models.ViewModels.Users
{
    public class LoginViewModel
    {
        [Regex(@"^\S*$")]
        public string Login { get; set; }

        [Regex(@"^\S*$")]
        public string Password { get; set; }
    }
}
