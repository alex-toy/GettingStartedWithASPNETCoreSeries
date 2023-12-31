﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ModelBindingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [BindProperties(SupportsGet = true)]
    [Consumes("application/xml", "application/json")]
    public class WeatherForecastController : ControllerBase
    {
        //[BindProperty(SupportsGet=true)]
        public bool IsSet { get; set; }

        [BindProperty(SupportsGet = true, Name="test")]
        public bool IsTestProp { get; set; }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public string Get(int id, bool isTest)
        {
            return $"id : {id} - isTest: {isTest} - IsSet: {IsSet} - IsTestProp: {IsTestProp}";
        }

        [HttpGet("test/{id}")]
        public string Get([FromQuery] int id, [FromHeader(Name = "Accept-Language")] string language)
        {
            return $"id : {id} - language : {language}";
        }

        [HttpGet("complex")]
        public string Get([FromQuery] MyComplexType complexType)
        {
            string parameters = $"Id : {complexType.Id} - Language : {complexType.Language} - IsBool : {complexType.IsBool}";

            if (complexType.Marks == null) return parameters;

            foreach (var mark in complexType.Marks)
            {
                parameters += $" mark {mark.ToString()}";
            }

            return parameters;
        }

        [HttpGet("complexbis")]
        public string GetComplex([FromQuery] MyComplexType complexType)
        {
            string parameters = $"Id : {complexType.Id} - Language : {complexType.Language} - IsBool : {complexType.IsBool}";

            if (complexType.Actions == null) return parameters;

            foreach (var action in complexType.Actions)
            {
                parameters += $" action {action.Key}={action.Value}";
            }

            return parameters;
        }

        [HttpPost("data")]
        public string PostData(MyCustomData myCustomData)
        {
            string parameters = $"Id : {myCustomData.Id} - Language : {myCustomData.Name}";

            return parameters;
        }
    }
}
