using System;
using System.Globalization;
using PetClinic.DataProcessor.Dto.Import;
using PetClinic.Models;

namespace PetClinic.App
{
    using AutoMapper;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            CreateMap<AnimalDto, Animal>();
            CreateMap<PassportDto, Passport>();
            CreateMap<VetDto, Vet>();
        }
    }
}
