using System.Collections.Generic;

namespace FlightScheduler.Models
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public int Day { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public int MaxCapacity { get; init; } = 20;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}