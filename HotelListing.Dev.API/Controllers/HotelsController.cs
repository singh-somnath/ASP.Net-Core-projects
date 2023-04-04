using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Dev.API.Data;
using AutoMapper;
using HotelListing.Dev.API.Contracts;
using HotelListing.Dev.API.Model.Hotel;

namespace HotelListing.Dev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHotelDto>>> GetHotels()
        {
            var hotels = await this._hotelRepository.GetAllAsync();
            var hotelListDto = this._mapper.Map<List<GetHotelDto>>(hotels);
            return Ok(hotelListDto);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetHotelDto>> GetHotel(int id)
        {
            var hotel = await this._hotelRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }
            var hotelDto = this._mapper.Map<GetHotelDto>(hotel);

            return Ok(hotelDto);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelDto updateHotelDto)
        {
            if (id != updateHotelDto.Id)
            {
                return BadRequest();
            }
            var hotel = await this._hotelRepository.GetAsync(id);

            if (hotel == null)
                return NotFound();


            try
            {
                this._mapper.Map(updateHotelDto, hotel);

                await this._hotelRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetHotelDto>> PostHotel(CreateHotelDto createHotelDto)
        {
            if (createHotelDto == null)
                return BadRequest();

            var hotel = this._mapper.Map<Hotel>(createHotelDto);

            var hotelResult = await this._hotelRepository.AddAsync(hotel);

            var getHotelDto = this._mapper.Map<GetHotelDto>(hotelResult);

            return CreatedAtAction("GetHotel", new { id = getHotelDto.Id}, getHotelDto);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await this._hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await this._hotelRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await this._hotelRepository.ItemExistAsync(id);
        }
    }
}
