namespace OBilet.Application.Features.Services.Configurations
{
    public interface IOBiletConfiguration
    {
        string BaseUri { get; set; }
        string AuthType { get; set; }
        string Token { get; set; }
        string MediaType { get; set; }
        public string GetBusLocationUri { get; set; }
        public string GetBusJourneysUri { get; set; }
        public string GetSessionUri { get; set; }
    }
}
