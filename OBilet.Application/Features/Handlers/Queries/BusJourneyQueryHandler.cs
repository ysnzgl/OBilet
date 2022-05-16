using MediatR;
using OBilet.Application.Categories.Mappings;
using OBilet.Application.Features.Categories.Queries;
using OBilet.Application.Features.Categories.Results;
using OBilet.Application.Features.Services;
using OBilet.Application.Features.Services.Models.Requests;
using OBilet.Application.Features.Services.Models.Responses;
using OBilet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Handlers.Queries
{
    public class BusJourneyQueryHandler : IRequestHandler<BusJourneyQuery, IQueryResult<List<BusJourneysDto>>>
    {
        private readonly IObiletService _obiletService;

        public BusJourneyQueryHandler(IObiletService obiletService)
        {
            _obiletService = obiletService;
        }

        public async Task<IQueryResult<List<BusJourneysDto>>> Handle(BusJourneyQuery request, CancellationToken cancellationToken)
        {
            BaseRequest<GetBusJourneysRequest> serviceRequest = ObjectMapper.Mapper.Map<BaseRequest<GetBusJourneysRequest>>(request);
            var response = await _obiletService.GetBusJourneysAsync(serviceRequest);
            var result = new List<BusJourneysDto>();
            if (response.Status == ResponseStatus.Success)
            {
                result = ObjectMapper.Mapper.Map<List<BusJourneysDto>>(response.Data);
                return new QueryResult<List<BusJourneysDto>>(result, true);
            }
            return new QueryResult<List<BusJourneysDto>>(result, false, response.Message);
        }
    }
}
