using HotelListing.Dev.API.Contracts;
using HotelListing.Dev.API.Data;

namespace HotelListing.Dev.API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelListingDBContext dBContext) : base(dBContext)
        {
        }
    }
}
