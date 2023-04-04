using Microsoft.Build.Framework;

namespace HotelListing.Dev.API.Model.Hotel
{
    public class UpdateHotelDto : BaseHotelDto
    {
        [Required]
        public int Id { get; set; }
    }
}
