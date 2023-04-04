using HotelListing.Dev.API.Data;

namespace HotelListing.Dev.API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>
    {
        public HotelRepository(HotelListingDBContext dBContext) : base(dBContext)
        {
        }
    }
}
