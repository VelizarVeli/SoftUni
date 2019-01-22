namespace EventuresWebApp.Web.Infrastructure
{
    using AutoMapper;
    using Models;    
    using Services.Models;
    using ViewModels.Accounts;
    using ViewModels.Events;

    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            this.CreateMap<RegisterViewModel, EventuresUser>();
            this.CreateMap<EventModel, EventViewModel>();
            this.CreateMap<OrderModel, EventViewModel>()
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.EventStart))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.EventEnd))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EventName));
        }
    }
}
