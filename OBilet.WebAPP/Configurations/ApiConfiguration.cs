namespace OBilet.WebAPP.Configurations
{
    public class ApiConfiguration: IApiConfiguration
    {
        public const string ServiceCollectorName = "Api";
        public string BaseUri { get; set; }
        public string MediaType { get; set; }
        public string GetBusLocationUri { get; set; }
        public string GetBusJourneysUri { get; set; }
        public string GetSessionUri { get; set; }
    }
}
