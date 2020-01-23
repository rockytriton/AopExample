using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherBac bacLayer;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherBac bacLayer)
        {
            this.bacLayer = bacLayer;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return bacLayer.FetchAll();
        }

        [HttpPost]
        public WeatherForecast Post(WeatherForecast weather) {
            bacLayer.InsertForecast(weather);
            return weather;
        }
    }
}
