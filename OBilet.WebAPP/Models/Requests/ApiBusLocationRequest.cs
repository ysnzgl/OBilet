using OBilet.Models.Dtos;
using System;

namespace OBilet.WebAPP.Models.Requests
{
    public class ApiBusLocationRequest
    {
        public ApiBusLocationRequest()
        {
            DeviceSession = new DeviceSessionDto();
        }
        public DeviceSessionDto DeviceSession { get; set; }
        public string Language => "tr-TR";
        public DateTime Date { get; set; } = DateTime.Now.AddDays(1);
        public string LocationName { get; set; }
    }
}
