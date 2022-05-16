using System;

namespace OBilet.Models.Dtos
{

    public class BusJourneysDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }

}
