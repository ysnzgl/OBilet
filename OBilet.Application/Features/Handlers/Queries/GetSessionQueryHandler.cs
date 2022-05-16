using MediatR;
using OBilet.Application.Categories.Mappings;
using OBilet.Application.Features.Categories.Queries;
using OBilet.Application.Features.Categories.Results;
using OBilet.Application.Features.Services;
using OBilet.Application.Features.Services.Models.Requests;
using OBilet.Application.Features.Services.Models.Responses;
using OBilet.Models.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Handlers.Queries
{
    public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, IQueryResult<DeviceSessionDto>>
    {
        private readonly IObiletService _obiletService;

        public GetSessionQueryHandler(IObiletService obiletService)
        {
            _obiletService = obiletService;
        }

        public async Task<IQueryResult<DeviceSessionDto>> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            GetSessionRequest serviceRequest = ObjectMapper.Mapper.Map<GetSessionRequest>(request);
            var response = await _obiletService.GetSessionAsync(serviceRequest);
            var result = new DeviceSessionDto();
            if (response.Status == ResponseStatus.Success)
            {
                result = ObjectMapper.Mapper.Map<DeviceSessionDto>(response.Data);
                return new QueryResult<DeviceSessionDto>(result, true);
            }
            return new QueryResult<DeviceSessionDto>(result, false, response.Message);
        }
    }
}
