using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DependencyService _dependencyService;
        private readonly DependencyServiceBis _dependencyServiceBis;
        private readonly IEnumerable<IOperationSingletonInstance> _operationSingletonInstances;
        private readonly Counter _counter;

        public WeatherForecastController(DependencyService dependencyService,
                                         DependencyServiceBis dependencyServiceBis,
                                         IEnumerable<IOperationSingletonInstance> operationSingletonInstance,
                                         Counter counter)
        {
            _dependencyService = dependencyService;
            _dependencyServiceBis = dependencyServiceBis;
            _operationSingletonInstances = operationSingletonInstance;
            _counter = counter;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            foreach (var operation in _operationSingletonInstances)
            {
                Console.WriteLine($"{operation.OperationId}");
            }

            return Enumerable.Empty<WeatherForecast>();
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    Console.WriteLine($"Call {_counter.Count}");
        //    _dependencyService.Write();
        //    _dependencyServiceBis.Write();

        //    return Enumerable.Empty<WeatherForecast>();
        //}
    }
}
