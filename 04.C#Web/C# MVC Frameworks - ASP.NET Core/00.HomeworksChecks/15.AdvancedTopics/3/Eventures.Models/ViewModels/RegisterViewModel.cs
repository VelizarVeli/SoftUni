using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventures.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression("[\\w,-^,_,.,*,~]{3,}", ErrorMessage = "Username is invalid!")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "First Name must be at least {1} characters long!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Last Name must be at least {1} characters long!")]
        [Display( Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "UCN must be exactly {1} characters long!")]
        [MaxLength(10, ErrorMessage = "UCN must be exactly {1} characters long!")]
        public string UCN { get; set; }
    }
}
