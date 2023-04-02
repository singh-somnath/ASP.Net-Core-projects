using System.ComponentModel.DataAnnotations;

namespace HotelListing.Dev.API.Model.Country
{
    public class CreateCountryDto
    {
        [Required]
        [MaxLength(199, ErrorMessage ="Maximum length allowed 199 charachters.")]
        public string Name { get;set; }
        [Required]
        [MaxLength(4, ErrorMessage = "Maximum length allowed 4 charachters.")]
        public string ShortName { get;set; }
    }
}
