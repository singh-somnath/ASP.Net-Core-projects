﻿namespace HotelListing.Dev.API.Model.Hotel
{
    public class GetHotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
      
    }
}
