namespace Eventures.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class EventureUser : IdentityUser
    {
        [Required]
        [MinLength(3)]
        [RegularExpression(@"[A-Za-z\~\-\\_\*]+")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "UNC")]
        public string UniqueCitizenNumber { get; set; }
    }
}