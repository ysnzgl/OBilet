using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OBilet.Models.Dtos;
using OBilet.WebAPP.Configurations;
using OBilet.WebAPP.Models;
using OBilet.WebAPP.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.WebAPP.Service
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly IApiConfiguration _apiConfiguration;
        private HttpContext _httpContext;
        public ApiService(IHttpClientFactory httpClientFactory, IApiConfiguration apiConfiguration)
        {
            _httpClientFactory = httpClientFactory;            
            _apiConfiguration = apiConfiguration;
            _httpClient = _httpClientFactory.CreateClient(ApiConfiguration.ServiceCollectorName);

        }

        public async Task<LocationViewModel> GetAllLocations(HttpContext httpContext)
        {
            _httpContext = httpContext;
            var ds = await GetDeviceSession();
            var request = new ApiBusLocationRequest();
            request.DeviceSession = ds;
            var paramater = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            var content = new StringContent(paramater, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            using var httpResponse = await _httpClient.PostAsync(_apiConfiguration.GetBusLocationUri, content);
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            List<BusLocationDto> locations = JsonConvert.DeserializeObject<List<BusLocationDto>>(responseString);
            return new LocationViewModel { Locations = locations };

        }
        public async Task<DeviceSessionDto> GetDeviceSession()
        {
            ApiGetSessionRequest request = new ApiGetSessionRequest();

            request.BrowserName = _httpContext.Request.Headers["User-Agent"].FirstOrDefault().Split()[0].Split("/")[0];
            request.BrowserVersion = _httpContext.Request.Headers["User-Agent"].FirstOrDefault().Split()[0].Split("/")[1];
            request.IpAdress = _httpContext.Connection.RemoteIpAddress.ToString();
            request.Port = _httpContext.Connection.RemotePort;
            var paramater = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            var content = new StringContent(paramater, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            using var httpResponse = await _httpClient.PostAsync(_apiConfiguration.GetSessionUri, content);
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            DeviceSessionDto deviceSessionDto = JsonConvert.DeserializeObject<DeviceSessionDto>(responseString);
            return deviceSessionDto;

        }

        public async Task<JourneyViewModel> GetJourneys(int origin, int destination, DateTime date, HttpContext httpContext)
        {
            _httpContext = httpContext;
            var viewmodel = new JourneyViewModel();
            var ds = await GetDeviceSession();
            var request = new ApiBusJourneyRequest();
            request.DeviceSession = ds;
            request.OriginId = origin;
            request.DestinationId = destination;
            request.Date = date;
            var paramater = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            var content = new StringContent(paramater, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            using var httpResponse = await _httpClient.PostAsync(_apiConfiguration.GetBusJourneysUri, content);
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            List<BusJourneysDto> journeys = JsonConvert.DeserializeObject<List<BusJourneysDto>>(responseString);
            viewmodel.Journeys = journeys;
            viewmodel.DestinationLocation = journeys.FirstOrDefault().Destination;
            viewmodel.OriginLocation = journeys.FirstOrDefault().Origin;
            viewmodel.Date = date;
            return viewmodel;
        }
    }
}
