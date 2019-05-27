using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Panda.Common.ViewModels.Packages
{
    public class CreatePackageViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [Range(0, 10000,
            ErrorMessage = "{0} must be between {1} and {2}.")]
        public double Weight { get; set; }

        [Required]
        public string Recipient { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Description { get; set; }

        public ICollection<string> Recipients { get; set; } = new List<string>();
    }
}