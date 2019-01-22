using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Relations.Models
{
 public   class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<StudentsCourses> Students { get; set; }
    }
}
