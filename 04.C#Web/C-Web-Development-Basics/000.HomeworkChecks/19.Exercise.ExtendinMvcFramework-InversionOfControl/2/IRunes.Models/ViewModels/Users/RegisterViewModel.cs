using SIS.Framework.Attributes.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Models.ViewModels.Users
{
    public class RegisterViewModel
    {
        [Regex(@"^[A-Za-z0-9_.-]+$")]
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
