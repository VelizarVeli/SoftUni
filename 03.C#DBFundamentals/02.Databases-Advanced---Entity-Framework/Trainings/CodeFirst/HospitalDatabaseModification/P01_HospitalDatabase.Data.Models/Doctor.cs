using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public int  DoctorId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
