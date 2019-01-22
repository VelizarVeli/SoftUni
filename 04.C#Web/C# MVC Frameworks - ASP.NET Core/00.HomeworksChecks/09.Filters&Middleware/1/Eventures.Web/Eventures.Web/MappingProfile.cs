namespace Eventures.Web
{
    using Eventures.Models;
    using ViewModels.Events;
    using AutoMapper;

    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventInfoViewModel, Event>().ReverseMap();
        }
    }
}