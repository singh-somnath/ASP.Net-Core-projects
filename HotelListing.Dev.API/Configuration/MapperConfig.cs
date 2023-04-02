using AutoMapper;
using HotelListing.Dev.API.Data;
using HotelListing.Dev.API.Model.Country;
using HotelListing.Dev.API.Model.Hotel;

namespace HotelListing.Dev.API.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country,CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDto>().ReverseMap();
            CreateMap<Hotel, GetHotelDto>().ReverseMap();
        }
    }
}
