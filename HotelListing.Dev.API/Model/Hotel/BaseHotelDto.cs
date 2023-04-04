using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Dev.API.Model.Hotel
{
    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string Address { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Contry Id must be valid country id.")]
        public int CountryId { get; set; }


    }
}
