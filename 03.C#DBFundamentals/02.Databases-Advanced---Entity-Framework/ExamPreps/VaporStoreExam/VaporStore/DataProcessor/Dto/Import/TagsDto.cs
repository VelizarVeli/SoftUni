using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
  public  class TagsDto
    {
        [Required]
        public string Name { get; set; }
    }
}
