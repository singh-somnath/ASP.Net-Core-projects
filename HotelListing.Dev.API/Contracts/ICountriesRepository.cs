using HotelListing.Dev.API.Data;

namespace HotelListing.Dev.API.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        public Task<Country> GetCountryDetails(int id);
    }
}
