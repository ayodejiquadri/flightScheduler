using FlightScheduler.Contracts;
using FlightScheduler.Models;
using FlightScheduler.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightScheduler.Services
{
    /// <summary>
    /// The Implementation of the <see cref="IFlightService"/>
    /// </summary>
    public class FlightService : IFlightService
    {
        /// <inheritdoc cref="IFlightService.GetFlights"/>
        public Task<ICollection<Flight>> GetFlights()
        {
            ICollection<Flight> flights = new List<Flight>
            {
                new Flight
                {
                    FlightNumber = "1",
                    Departure = Airports.Montreal,
                    Destination = Airports.Toronto,
                    Day = 1
                },
                new Flight
                {
                    FlightNumber = "2",
                    Departure = Airports.Montreal,
                    Destination = Airports.Calgary,
                    Day = 1
                },
                new Flight
                {
                    FlightNumber = "3",
                    Departure = Airports.Montreal,
                    Destination = Airports.Vancouver,
                    Day = 1
                },
                new Flight
                {
                    FlightNumber = "4",
                    Departure = Airports.Montreal,
                    Destination = Airports.Toronto,
                    Day = 2
                },
                new Flight
                {
                    FlightNumber = "5",
                    Departure = Airports.Montreal,
                    Destination = Airports.Calgary,
                    Day = 2
                },
                new Flight
                {
                    FlightNumber = "6",
                    Departure = Airports.Montreal,
                    Destination = Airports.Vancouver,
                    Day = 2
                }
            };

            return Task.FromResult(flights);
        }
    }
}