using OBilet.Models.Dtos;
using System;
using System.Collections.Generic;

namespace OBilet.WebAPP.Models
{
    public class JourneyViewModel
    {
        public JourneyViewModel()
        {
            Journeys = new List<BusJourneysDto>();
        }
        public string OriginLocation { get; set; }
        public DateTime Date { get; set; }
        public string DestinationLocation { get; set; }
        public List<BusJourneysDto> Journeys { get; set; }
    }
}
