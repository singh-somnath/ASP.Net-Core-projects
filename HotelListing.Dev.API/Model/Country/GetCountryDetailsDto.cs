using HotelListing.Dev.API.Model.Hotel;

namespace HotelListing.Dev.API.Model.Country
{
    public class GetCountryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual IList<GetHotelDto> Hotels { get; set; }
    }
}
