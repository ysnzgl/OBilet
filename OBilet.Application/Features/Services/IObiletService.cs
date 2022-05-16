using OBilet.Application.Features.Services.Models.Requests;
using OBilet.Application.Features.Services.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Services
{
    public interface IObiletService
    {
        Task<BaseResponse<GetSessionResponse>> GetSessionAsync(GetSessionRequest request);
        Task<BaseResponse<List<GetBusLocationResponse>>> GetBusLocationAsync(BaseRequest<string> request);
        Task<BaseResponse<List<GetBusJourneysResponse>>> GetBusJourneysAsync(BaseRequest<GetBusJourneysRequest> request);
    }
}
