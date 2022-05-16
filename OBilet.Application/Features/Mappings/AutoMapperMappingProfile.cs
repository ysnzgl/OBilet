using AutoMapper;
using OBilet.Application.Features.Categories.Queries;
using OBilet.Application.Features.Services.Models.Requests;
using OBilet.Application.Features.Services.Models.Responses;
using OBilet.Models.Dtos;

namespace OBilet.Application.Categories.Mappings
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<DeviceSessionDto, DeviceSession>().ReverseMap();

            CreateMap<BusLocationQuery, BaseRequest<string>>()
                .ForMember(d => d.DeviceSession, o => o.MapFrom(s => s.DeviceSession))
                .ForMember(d => d.Data, o => o.MapFrom(s => s.LocationName))
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                ;



            CreateMap<GetBusLocationResponse, BusLocationDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                ;

            CreateMap<GetSessionQuery, GetSessionRequest>()
                .ForMember(d => d.Connection, o => o.MapFrom(s => new Connections { IpAddress = s.IpAdress, Port = s.Port.ToString() }))
                .ForMember(d => d.Browser, o => o.MapFrom(s => new Browsers { Name = s.BrowserName, Version = s.BrowserVersion }))
                .ForMember(d => d.Type, o => o.MapFrom(s => 1))
                ;

            CreateMap<GetSessionResponse, DeviceSessionDto>()
                .ForMember(d => d.DeviceId, o => o.MapFrom(s => s.DeviceId))
                .ForMember(d => d.SessionId, o => o.MapFrom(s => s.SessionId))
                ;

            CreateMap<BusJourneyQuery, GetBusJourneysRequest>()
                .ForMember(d => d.DestinationId, o => o.MapFrom(s => s.DestinationId))
                .ForMember(d => d.OriginId, o => o.MapFrom(s => s.OriginId))
                .ForMember(d => d.DepartureDate, o => o.MapFrom(s => s.Date.ToString("yyyy-MM-dd")))
                ;

            CreateMap<BusJourneyQuery, BaseRequest<GetBusJourneysRequest>>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                .ForMember(d => d.DeviceSession, o => o.MapFrom(s => s.DeviceSession))
                .ForMember(d => d.Data, o => o.MapFrom(s => s))
                ;

            CreateMap<GetBusJourneysResponse, BusJourneysDto>()
                .ForMember(d => d.Origin, o => o.MapFrom(s => s.Journey.Origin))
                .ForMember(d => d.Destination, o => o.MapFrom(s => s.Journey.Destination))
                .ForMember(d => d.Departure, o => o.MapFrom(s => s.Journey.Departure))
                .ForMember(d => d.Arrival, o => o.MapFrom(s => s.Journey.Arrival))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Journey.OriginalPrice))
                .ForMember(d => d.Currency, o => o.MapFrom(s => s.Journey.Currency))
                ;

        }
    }
}
