using MediatR;
using OBilet.Application.Features.Categories.Results;
using OBilet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Application.Features.Categories.Queries
{
    public class BusJourneyQuery : IRequest<IQueryResult<List<BusJourneysDto>>>
    {
        public BusJourneyQuery()
        {
            DeviceSession = new DeviceSessionDto();
        }
        public DateTime Date { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DeviceSessionDto DeviceSession { get; set; }
        public string Language { get; set; }
    }
}
