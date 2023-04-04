using HotelListing.Dev.API.Contracts;
using HotelListing.Dev.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Dev.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDBContext _dbContext;
        public GenericRepository(HotelListingDBContext dBContext)
        {
            this._dbContext = dBContext;
        }
        public async Task<T> AddAsync(T Entity)
        {
            await this._dbContext.AddAsync(Entity);
            await this._dbContext.SaveChangesAsync();

            return Entity;
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await GetAsync(Id);
            if(entity != null)
            {
                this._dbContext.Remove(entity);
                await this._dbContext.SaveChangesAsync();
            }
           
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int Id)
        {
            return await this._dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<bool> ItemExistAsync(int Id)
        {
            var entity = await GetAsync(Id);
            return entity != null;
        }

        public async Task UpdateAsync(T Entity)
        {
            this._dbContext.Update(Entity);
            await this._dbContext.SaveChangesAsync();
           
        }
    }
}
