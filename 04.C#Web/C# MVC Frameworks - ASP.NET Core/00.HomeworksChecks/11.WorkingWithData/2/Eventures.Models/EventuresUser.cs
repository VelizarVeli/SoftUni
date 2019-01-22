using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    using Eventures.Models.Enum;
    using Microsoft.AspNetCore.Identity;

    public class EventuresUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string UCN { get; set; }
        public RoleType Role { get; set; }
    }
}
