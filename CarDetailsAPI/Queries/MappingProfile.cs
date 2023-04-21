using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CarDetailsAPI.Queries
{
    public class MappingProfile : Profile
    {


        public MappingProfile()
        {


            CreateMap<CarDetailsModels.Manufacturer, CarDetailsAPI.Models.ManufacturersModel>()
                .ForMember(dest => dest.MappedName, dest => dest.MapFrom(src => src.Name))
                .ForMember(dest => dest.MappedHeadquarters, dest => dest.MapFrom(src => src.Headquarters))
                .ForMember(dest => dest.MappedYear, dest => dest.MapFrom(src => src.Year));

            CreateMap<CarDetailsModels.Car, CarDetailsAPI.Models.CarsModel>()
                .ForMember(dest => dest.MappedYear, dest => dest.MapFrom(src => src.Year))
                .ForMember(dest => dest.MappedManufacturer, dest => dest.MapFrom(src => src.Manufacturer))
                .ForMember(dest => dest.MappedName, dest => dest.MapFrom(src => src.Name))
                .ForMember(dest => dest.MappedDisplacement, dest => dest.MapFrom(src => src.Displacement))
                .ForMember(dest => dest.MappedCylinders, dest => dest.MapFrom(src => src.Cylinders))
                .ForMember(dest => dest.MappedCity, dest => dest.MapFrom(src => src.City))
                .ForMember(dest => dest.MappedHighway, dest => dest.MapFrom(src => src.Highway))
                .ForMember(dest => dest.MappedCombined, dest => dest.MapFrom(src => src.Combined));

        }
    }
}



