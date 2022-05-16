using Newtonsoft.Json;
using System;

namespace OBilet.Application.Features.Services.Models.Requests
{
    public class BaseRequest<T>
    {
        public BaseRequest()
        {
            DeviceSession = new DeviceSession();
        }
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("date")]
        public DateTime? Date {get;set;}

        [JsonProperty("language")]
        public string Language { get; set; }

    }

    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
