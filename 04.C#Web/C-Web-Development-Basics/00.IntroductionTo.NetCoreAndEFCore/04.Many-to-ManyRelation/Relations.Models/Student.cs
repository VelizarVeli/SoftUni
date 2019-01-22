using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Relations.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<StudentsCourses> Courseses { get; set; } = new List<StudentsCourses>();
    }
}
