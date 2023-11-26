namespace FlightScheduler.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string Destination { get; set; }
        public int Priority { get; set; }
        public Flight Flight { get; set; }
    }
}