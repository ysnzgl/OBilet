using MediatR;
using OBilet.Application.Features.Categories.Results;
using OBilet.Models.Dtos;
using System;
using System.Collections.Generic;

namespace OBilet.Application.Features.Categories.Queries
{
    public class BusLocationQuery : IRequest<IQueryResult<List<BusLocationDto>>>
    {
        public BusLocationQuery()
        {
            DeviceSession = new DeviceSessionDto();
        }
        public DeviceSessionDto DeviceSession { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
        public string LocationName { get; set; }
        //public int? OriginId { get; set; }
        //public int? DestinationId { get; set; }
    }
}
