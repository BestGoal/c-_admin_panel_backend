using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsManagemtns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DbContextImpl _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DbContextImpl context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        public List<string> Get()
        {

            return new List<String> { "Salim" };
        }
    }
}
