using Newtonsoft.Json;

namespace OBilet.Application.Features.Services.Models.Requests
{
    public  class GetBusJourneysRequest
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public string DepartureDate { get; set; }
    }
}
