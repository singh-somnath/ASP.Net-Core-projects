using System.ComponentModel.DataAnnotations;

namespace HotelListing.Dev.API.Data
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(199)]
        public string Name { get; set; }
        [MaxLength(4)]
        public string ShortName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }

    }
}
