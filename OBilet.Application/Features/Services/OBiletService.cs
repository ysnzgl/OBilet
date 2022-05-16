using Newtonsoft.Json;
using OBilet.Application.Features.Services.Configurations;
using OBilet.Application.Features.Services.Models.Requests;
using OBilet.Application.Features.Services.Models.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Services
{
    public class OBiletService : IObiletService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly IOBiletConfiguration _obiletConfiguration;
        public OBiletService(IHttpClientFactory httpClientFactory, IOBiletConfiguration oBiletConfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient(OBiletConfiguration.ServiceCollectorName);
            _obiletConfiguration = oBiletConfiguration;
        }

        public async Task<BaseResponse<List<GetBusJourneysResponse>>> GetBusJourneysAsync(BaseRequest<GetBusJourneysRequest> request)
        {
            var paramater = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            var content = new StringContent(paramater, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            using var httpResponse = await _httpClient.PostAsync(_obiletConfiguration.GetBusJourneysUri, content);
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponse<List<GetBusJourneysResponse>>>(responseString);
            return response;
        }

        public async Task<BaseResponse<List<GetBusLocationResponse>>> GetBusLocationAsync(BaseRequest<string> request)
        {
            var paramater = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            var content = new StringContent(paramater, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            using var httpResponse = await _httpClient.PostAsync(_obiletConfiguration.GetBusLocationUri, content);
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponse<List<GetBusLocationResponse>>>(responseString);
            return response;
        }

        public async Task<BaseResponse<GetSessionResponse>> GetSessionAsync(GetSessionRequest request)
        {
            var paramater = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

            var content = new StringContent(paramater, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            using var httpResponse = await _httpClient.PostAsync(_obiletConfiguration.GetSessionUri, content);
            httpResponse.EnsureSuccessStatusCode();
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponse<GetSessionResponse>>(responseString);
            return response;
        }
    }
}
