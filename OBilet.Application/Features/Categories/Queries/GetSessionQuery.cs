using MediatR;
using OBilet.Application.Features.Categories.Results;
using OBilet.Models.Dtos;

namespace OBilet.Application.Features.Categories.Queries
{
    public class GetSessionQuery : IRequest<IQueryResult<DeviceSessionDto>>
    {
        public string IpAdress { get; set; }
        public int Port { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
    }
}
