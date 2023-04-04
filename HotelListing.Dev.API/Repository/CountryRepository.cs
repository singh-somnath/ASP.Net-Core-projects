using HotelListing.Dev.API.Contracts;
using HotelListing.Dev.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Dev.API.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDBContext _DBContext;
        public CountryRepository(HotelListingDBContext dBContext) : base(dBContext)
        {
            _DBContext = dBContext;
        }



        public async Task<Country> GetCountryDetails(int id)
        {
            return await this._DBContext.Set<Country>().Include(c => c.Hotels).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
