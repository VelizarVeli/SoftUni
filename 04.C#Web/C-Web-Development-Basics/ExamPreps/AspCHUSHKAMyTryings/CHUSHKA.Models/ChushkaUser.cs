using Microsoft.AspNetCore.Identity;

namespace CHUSHKA.Models
{
    public class ChushkaUser :IdentityUser
    {
        public string FullName { get; set; }
    }
}
