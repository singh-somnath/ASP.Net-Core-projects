using System.ComponentModel.DataAnnotations;

namespace HotelListing.Dev.API.Model.Country
{
    public class UpdateCountryDto : BaseCountryDto
    {
        [Required]
        public int Id { get; set; }
    }
}
