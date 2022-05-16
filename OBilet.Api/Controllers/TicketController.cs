using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OBilet.Application.Features.Categories.Queries;
using OBilet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBilet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        private const string locationKey = "Locations";


        public TicketController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        [Route("GetLocationsAsync")]
        [HttpPost]
        public async Task<ActionResult<List<BusLocationDto>>> GetLocationsAsync(BusLocationQuery query)
        {
            List<BusLocationDto> busLocations;
            _memoryCache.TryGetValue(locationKey, out busLocations);
            string locationName = query.LocationName;
            if (busLocations == null)
            {
                query.LocationName = null;
                var result = await _mediator.Send(query);
                _memoryCache.Set(locationKey, result.Data);
                busLocations = result.Data;
            }

            if (!string.IsNullOrEmpty(locationName))
                busLocations = busLocations.Where(x => x.Name.Contains(locationName)).ToList();
            return Ok(busLocations);


        }

        [Route("GetSessionAsync")]
        [HttpPost]
        public async Task<ActionResult<DeviceSessionDto>> GetSessionAsync(GetSessionQuery query)
        {
            string userKey = query.BrowserName + query.BrowserVersion + query.IpAdress + query.Port;
            DeviceSessionDto device;
            _memoryCache.TryGetValue(userKey, out device);
            if (device == null)
            {
                var result = await _mediator.Send(query);
                _memoryCache.Set(userKey, result.Data, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) });
                device = result.Data;
            }

            return Ok(device);
        }

        [Route("GetJourneysAsync")]
        [HttpPost]
        public async Task<ActionResult<DeviceSessionDto>> GetJourneysAsync(BusJourneyQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result.Data);
        }
        ~TicketController()
        {
            _memoryCache.Remove(locationKey);
        }
    }
}
