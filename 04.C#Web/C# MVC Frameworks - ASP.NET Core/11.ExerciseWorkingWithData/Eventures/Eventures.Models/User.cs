using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string  FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [Range(10, 10)]
        public string  UCN { get; set; }
    }
}
