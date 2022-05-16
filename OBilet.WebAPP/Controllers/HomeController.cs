using Microsoft.AspNetCore.Mvc;
using OBilet.WebAPP.Models;
using OBilet.WebAPP.Service;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OBilet.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(LocationViewModel viewModel)
        {
            viewModel = await _apiService.GetAllLocations(HttpContext);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> JourneyAsync(LocationViewModel model)
        {            
            var viewmodel = await _apiService.GetJourneys(model.OriginId.Value, model.DestinationId.Value, model.Date,HttpContext);
            return View(viewmodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
