using HotelListing.Dev.API.Model.Hotel;

namespace HotelListing.Dev.API.Model.Country
{
    public class GetCountryDetailsDto : BaseCountryDto
    {
        public int Id { get; set; }
    
        public virtual IList<GetHotelDto> Hotels { get; set; }
    }
}
