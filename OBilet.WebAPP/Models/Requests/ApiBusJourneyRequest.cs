using OBilet.Models.Dtos;
using System;

namespace OBilet.WebAPP.Models.Requests
{
    public class ApiBusJourneyRequest
    {
        public ApiBusJourneyRequest()
        {
            DeviceSession = new DeviceSessionDto();
        }
        public DateTime Date { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public DeviceSessionDto DeviceSession { get; set; }
        public string Language => "tr-TR";

    }
}
