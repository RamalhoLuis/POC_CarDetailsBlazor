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


            //CreateMap<CarDetailsAPI.Models.ManufacturersModel, CarDetailsModels.Manufacturer>()
            //    .ForMember(dest => dest.Name, dest => dest.MapFrom(src => src.MappedName))
            //    .ForMember(dest => dest.Headquarters, dest => dest.MapFrom(src => src.MappedHeadquarters))
            //    .ForMember(dest => dest.Year, dest => dest.MapFrom(src => src.MappedYear));

            //CreateMap<CarDetailsAPI.Models.CarsModel, CarDetailsModels.Car>()
            //    .ForMember(dest => dest.Year, dest => dest.MapFrom(src => src.MappedYear))
            //    .ForMember(dest => dest.Manufacturer, dest => dest.MapFrom(src => src.MappedManufacturer))
            //    .ForMember(dest => dest.Name, dest => dest.MapFrom(src => src.MappedName))
            //    .ForMember(dest => dest.Displacement, dest => dest.MapFrom(src => src.MappedDisplacement))
            //    .ForMember(dest => dest.Cylinders, dest => dest.MapFrom(src => src.MappedCylinders))
            //    .ForMember(dest => dest.City, dest => dest.MapFrom(src => src.MappedCity))
            //    .ForMember(dest => dest.Highway, dest => dest.MapFrom(src => src.MappedHighway))
            //    .ForMember(dest => dest.Combined, dest => dest.MapFrom(src => src.MappedCombined));

            CreateMap<CarDetailsModels.Manufacturer, CarDetailsAPI.Models.ManufacturersModel>()
                .ForMember(dest => dest.MappedName, dest => dest.MapFrom(src => src.Name))
                .ForMember(dest => dest.MappedHeadquarters, dest => dest.MapFrom(src => src.Headquarters))
                .ForMember(dest => dest.MappedYear, dest => dest.MapFrom(src => src.Year)).ReverseMap();

            CreateMap<CarDetailsModels.Car, CarDetailsAPI.Models.CarsModel>()
                .ForMember(dest => dest.MappedYear, dest => dest.MapFrom(src => src.Year))
                .ForMember(dest => dest.MappedManufacturer, dest => dest.MapFrom(src => src.Manufacturer))
                .ForMember(dest => dest.MappedName, dest => dest.MapFrom(src => src.Name))
                .ForMember(dest => dest.MappedDisplacement, dest => dest.MapFrom(src => src.Displacement))
                .ForMember(dest => dest.MappedCylinders, dest => dest.MapFrom(src => src.Cylinders))
                .ForMember(dest => dest.MappedCity, dest => dest.MapFrom(src => src.City))
                .ForMember(dest => dest.MappedHighway, dest => dest.MapFrom(src => src.Highway))
                .ForMember(dest => dest.MappedCombined, dest => dest.MapFrom(src => src.Combined)).ReverseMap();




        }
    }
}



