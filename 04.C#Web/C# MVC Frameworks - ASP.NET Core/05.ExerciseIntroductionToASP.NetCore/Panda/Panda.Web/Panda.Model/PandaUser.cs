using Microsoft.AspNetCore.Identity;

namespace Panda.Model
{
    public class PandaUser : IdentityUser
    {
        public override string UserName { get; set; }
    }
}
