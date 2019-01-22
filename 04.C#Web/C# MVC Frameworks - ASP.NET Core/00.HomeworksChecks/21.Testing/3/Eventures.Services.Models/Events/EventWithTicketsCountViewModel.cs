using AutoMapper;
using Eventures.Mapping;
using Eventures.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Models.Events
{
    public class EventWithTicketsCountViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Event name should be at least 10 symbols long.")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Tickets")]
        public int TicketsCount { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Event, EventWithTicketsCountViewModel>()
                .ForMember(x => x.TicketsCount, x => x.MapFrom(j => j.TotalTickets));
        }
    }
}
