using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Areas.Administration.Models
{
    public class AddUserToRoleFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
