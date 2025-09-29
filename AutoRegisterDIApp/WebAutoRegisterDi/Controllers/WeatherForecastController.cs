using Microsoft.AspNetCore.Mvc;
using WebAutoRegisterDi.Services;

namespace WebAutoRegisterDi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogService logService) : ControllerBase
    {
        private readonly ILogService logService = logService;

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            logService.LogInfo("GetWeatherForecast");
            return Ok("GetWeatherForecast");
        }
    }
}
