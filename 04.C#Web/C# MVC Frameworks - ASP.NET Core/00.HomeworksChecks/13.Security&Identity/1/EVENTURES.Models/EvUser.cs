using EVENTURES.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EVENTURES.Models
{
    public class EvUser : IdentityUser
    {
        [Required]        
        [RegularExpression("^[a-zA-Z0-9-_.*~]{3,}$", ErrorMessage = "Username must be at least 3 characters long and can only contain alphanumeric characters dashes and underscores dots, asterisks and tildes.")]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UCN { get; set; }
    }
}
