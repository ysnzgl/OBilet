using Microsoft.AspNetCore.Http;
using OBilet.Models.Dtos;
using OBilet.WebAPP.Models;
using System;
using System.Threading.Tasks;

namespace OBilet.WebAPP.Service
{
    public interface IApiService
    {
        Task<LocationViewModel> GetAllLocations(HttpContext httpContext);
        Task<DeviceSessionDto> GetDeviceSession();
        Task<JourneyViewModel> GetJourneys(int origin, int destination, DateTime date, HttpContext httpContext);
    }
}
