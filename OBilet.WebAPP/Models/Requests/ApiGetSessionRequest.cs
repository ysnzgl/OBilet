namespace OBilet.WebAPP.Models.Requests
{
    public class ApiGetSessionRequest
    {
        public string IpAdress { get; set; }
        public int Port { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }

    }
}
