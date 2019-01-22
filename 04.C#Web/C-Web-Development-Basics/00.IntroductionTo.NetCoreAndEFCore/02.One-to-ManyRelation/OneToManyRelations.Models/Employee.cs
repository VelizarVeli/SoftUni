using System;
using System.ComponentModel.DataAnnotations;

namespace OneToManyRelations.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
