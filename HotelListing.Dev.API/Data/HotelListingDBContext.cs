using Microsoft.EntityFrameworkCore;

namespace HotelListing.Dev.API.Data
{
    public class HotelListingDBContext : DbContext
    {
        public HotelListingDBContext(DbContextOptions options):base(options)
        {
            
        }

        
    }
}
