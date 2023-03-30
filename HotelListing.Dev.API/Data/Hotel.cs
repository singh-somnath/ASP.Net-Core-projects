using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Dev.API.Data
{
    public class Hotel
    {
        public int Id { get; set; }

        [MaxLength(199)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string Address { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public double Rating { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }

        public Country Country { get; set; }

    }
}
