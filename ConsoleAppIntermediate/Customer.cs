using System.Collections.Generic;

namespace ConsoleAppIntermediate
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            this.Orders = new List<Order>();
        }

    }
}