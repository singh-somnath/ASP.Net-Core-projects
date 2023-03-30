using Microsoft.EntityFrameworkCore;

namespace HotelListing.Dev.API.Data
{
    public class HotelListingDBContext : DbContext
    {
        public HotelListingDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "India", ShortName = "IN" },
                new Country { Id = 2, Name = "United State Of America", ShortName = "USA" },
                new Country { Id = 3, Name = "United Kingdom", ShortName = "UK" }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Taj Hotel", Address = "City Square, Mumbai", Rating = 4.9, CountryId = 1, Description = "5 Star Hotel" },
                new Hotel { Id = 2, Name = "Hollywood Hotel", Address = "City Center, California", Rating = 4.7, CountryId = 2, Description = "5 Star Hotel" },
                new Hotel { Id = 3, Name = "British Heritage Hotel", Address = "Eight Square, London", Rating = 5, CountryId = 3, Description = "8 Star Hotel" }
            );
        }


    }
}
