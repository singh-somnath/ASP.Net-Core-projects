using HotelListing.Dev.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Dev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly HotelListingDBContext _dBContext;
        public CountryController(HotelListingDBContext dbContext)
        {
            _dBContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            return await _dBContext.Countries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _dBContext.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            try
            {
                await _dBContext.Countries.AddAsync(country);
                await _dBContext.SaveChangesAsync();

                return CreatedAtAction("GetCountry", new { id = country.Id }, country);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCountry(int id, Country country)
        { 
            if(id != country.Id)
            {
                return BadRequest("Invlaid Record ID");
            }

            _dBContext.Entry(country).State = EntityState.Modified;
            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var country = await _dBContext.Countries.FindAsync(id);
            if(country == null)
            {
               return NotFound();
            }
            _dBContext.Countries.Remove(country);
            _dBContext.SaveChanges();
            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _dBContext.Countries.Find(id) != null; 
        }
    }
}
