namespace OBilet.Application.Features.Services.Configurations
{
    public class OBiletConfiguration : IOBiletConfiguration
    {
        public const string ServiceCollectorName = "OBilet";
        public string BaseUri { get; set; }
        public string AuthType { get; set; }
        public string Token { get; set; }
        public string MediaType { get; set; }
        public string GetBusLocationUri { get; set; }
        public string GetBusJourneysUri { get; set; }
        public string GetSessionUri { get; set; }
    }
}
