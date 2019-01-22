using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OneToManyRelations.Models
{
   public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
