namespace HotelListing.Dev.API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T Entity);
        public Task UpdateAsync(T Entity);
        public Task<T> GetAsync(int Id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task DeleteAsync(int Id);
        public Task<bool> ItemExistAsync(int Id);

       
    }
}
