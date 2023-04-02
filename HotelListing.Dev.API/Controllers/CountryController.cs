using AutoMapper;
using HotelListing.Dev.API.Configuration;
using HotelListing.Dev.API.Data;
using HotelListing.Dev.API.Model.Country;
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
        private readonly IMapper _mapper;

        public CountryController(HotelListingDBContext dbContext, IMapper mapper)
        {
            _dBContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountry()
        {
            var countries = await _dBContext.Countries.ToListAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetailsDto>> GetCountry(int id)
        {
            var country = await _dBContext.Countries.Include(c => c.Hotels).FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            var countryDetailsDto = _mapper.Map<GetCountryDetailsDto>(country);

            return Ok(countryDetailsDto);
        }
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            try
            {
                var country = _mapper.Map<Country>(createCountry);

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
            if (id != country.Id)
            {
                return BadRequest("Invlaid Record ID");
            }

            _dBContext.Entry(country).State = EntityState.Modified;
            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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
            if (country == null)
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
