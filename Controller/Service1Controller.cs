using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SOAP.Model;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service1Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Service1Controller> _logger;

        public Service1Controller(ILogger<Service1Controller> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Produces("application/xml")]
        public IActionResult Post(SOAPRequestEnvelope env)
        {
            var rng = new Random();
            var res = new SOAPResponseEnvelope();
            res.Body.GetWeatherForecastResponse = new GetWeatherForecastResponse()
            {
                WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
            .ToArray()
            };
            return Ok(res);
        }
    }
}