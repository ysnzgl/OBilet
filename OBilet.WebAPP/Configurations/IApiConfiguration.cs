namespace OBilet.WebAPP.Configurations
{
    public interface IApiConfiguration
    {
        string BaseUri { get; set; }
        string MediaType { get; set; }
        public string GetBusLocationUri { get; set; }
        public string GetBusJourneysUri { get; set; }
        public string GetSessionUri { get; set; }
    }
}
