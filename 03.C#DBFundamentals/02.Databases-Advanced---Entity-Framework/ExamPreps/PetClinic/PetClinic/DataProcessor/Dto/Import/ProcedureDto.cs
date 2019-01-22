using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using PetClinic.Models;

namespace PetClinic.DataProcessor.Dto.Import
{
    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        public string Vet { get; set; }

        [Required]
        public string Animal { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public AnimalAidProcedureDto[] AnimalAids { get; set; }
    }
}
