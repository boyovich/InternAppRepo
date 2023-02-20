using Hangfire;
using InternApp.API.Models;
using InternApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InternApp.API.Controllers
{
    [ApiController]
    [Route("/Weather")]
    public class WeatherController : ControllerBase
    {
        private WeatherService _weatherService { get; set; }
        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet()]
        public ActionResult<List<WeatherForecast>> Get()
        {
            return Ok(_weatherService.Get());
        }
    }
}
