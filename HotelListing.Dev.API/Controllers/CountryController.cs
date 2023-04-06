using AutoMapper;
using HotelListing.Dev.API.Configuration;
using HotelListing.Dev.API.Contracts;
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
     
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountryController(IMapper mapper, ICountriesRepository countriesRepository)
        {
              _mapper = mapper;
            _countriesRepository = countriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountry()
        {
            var countries = await this._countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetailsDto>> GetCountry(int id)
        {
            var country = await this._countriesRepository.GetCountryDetails(id);
            if (country == null)
            {
                return NotFound();
            }
            else 
            {
                return NoContent();
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
                await this._countriesRepository.AddAsync(country);
                return CreatedAtAction("GetCountry", new { id = country.Id }, country);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCountry(int id, UpdateCountryDto updateCountry)
        {

            if (id != updateCountry.Id)
            {
                return BadRequest("Invlaid Record ID");
            }
            var country = await this._countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCountry, country);

            try
            {
                await this._countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var country = await this._countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            await this._countriesRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await this._countriesRepository.ItemExistAsync(id);
        }
    }
}
