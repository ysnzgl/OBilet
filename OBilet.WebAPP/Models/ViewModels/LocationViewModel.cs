using OBilet.Models.Dtos;
using System;
using System.Collections.Generic;

namespace OBilet.WebAPP.Models
{

    public class LocationViewModel
    {
        public DateTime Date { get; set; } = DateTime.Now.AddDays(1);
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public List<BusLocationDto> Locations { get; set; }
    }

}
