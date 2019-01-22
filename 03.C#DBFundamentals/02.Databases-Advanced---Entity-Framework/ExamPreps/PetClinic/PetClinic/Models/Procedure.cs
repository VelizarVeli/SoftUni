using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PetClinic.Models
{
   public class Procedure
    {
        public Procedure()
        {
            this.ProcedureAnimalAids = new List<ProcedureAnimalAid>();
        }

        [Key]
        public int Id { get; set; }

        public int AnimalId { get; set; }
        [Required]
        public Animal Animal { get; set; }

        public int VetId { get; set; }
        [Required]
        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }

        public decimal Cost => this.ProcedureAnimalAids.Sum(s => s.AnimalAid.Price);

        [Required]
        public DateTime DateTime { get; set; }
    }
}
