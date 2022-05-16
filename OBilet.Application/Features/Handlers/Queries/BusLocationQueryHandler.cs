using MediatR;
using OBilet.Application.Categories.Mappings;
using OBilet.Application.Features.Categories.Queries;
using OBilet.Application.Features.Categories.Results;
using OBilet.Application.Features.Services;
using OBilet.Application.Features.Services.Models.Requests;
using OBilet.Application.Features.Services.Models.Responses;
using OBilet.Models.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Handlers.Queries
{
    public class BusLocationQueryHandler : IRequestHandler<BusLocationQuery, IQueryResult<List<BusLocationDto>>>
    {
        private readonly IObiletService _obiletService;

        public BusLocationQueryHandler(IObiletService obiletService)
        {
            _obiletService = obiletService;
        }

        public async Task<IQueryResult<List<BusLocationDto>>> Handle(BusLocationQuery request, CancellationToken cancellationToken)
        {
            BaseRequest<string> serviceRequest = ObjectMapper.Mapper.Map<BaseRequest<string>>(request);
            var response = await _obiletService.GetBusLocationAsync(serviceRequest);
            var result = new List<BusLocationDto>();
            if (response.Status == ResponseStatus.Success)
            {
                result = ObjectMapper.Mapper.Map<List<BusLocationDto>>(response.Data);
                return new QueryResult<List<BusLocationDto>>(result, true);
            }
            return new QueryResult<List<BusLocationDto>>(result, false, response.Message);
        }
    }
}
