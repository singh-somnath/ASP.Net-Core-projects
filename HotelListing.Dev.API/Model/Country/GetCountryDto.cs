using HotelListing.Dev.API.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Dev.API.Model.Country
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
