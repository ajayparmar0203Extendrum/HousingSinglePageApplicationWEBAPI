using HousingSinglePageApplicationWEBAPI.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using HousingSinglePageApplicationWEBAPI.Models;
using Property = HousingSinglePageApplicationWEBAPI.Models.Property;

namespace HousingSinglePageApplicationWEBAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDtocs>().ReverseMap();

            CreateMap<City, CityUpdateDto>().ReverseMap();

            CreateMap<Property, PropertyDto>().ReverseMap();

            CreateMap<Photo, PhotoDto>().ReverseMap();

            CreateMap<Property, PropertyListDto>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(d => d.Country, opt => opt.MapFrom(src => src.City.Country))
                .ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name))
                .ForMember(d => d.Photo, opt => opt.MapFrom(src => src.Photos
                                .FirstOrDefault(p => p.IsPrimary).ImageUrl));

            //CreateMap<Property, PropertyDetailDto>()
            //    .ForMember(d => d.City, opt => opt.MapFrom(src => src.City.Name))
            //    .ForMember(d => d.Country, opt => opt.MapFrom(src => src.City.Country))
            //    .ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name))
            //    .ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name));


            CreateMap<FurnishingType, KeyValuePairDto>();

            CreateMap<PropertyType, KeyValuePairDto>();

        }
    }
}
