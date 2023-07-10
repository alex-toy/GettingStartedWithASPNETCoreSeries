using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace FilterApp.Filters
{
    public class ResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<ResultFilterAttribute> _logger;
        private readonly string _name;
        private readonly Guid _randomId;

        public ResultFilterAttribute(ILogger<ResultFilterAttribute> logger, string name = "gobal")
        {
            _logger = logger;
            _name = name;
            _randomId = Guid.NewGuid();
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($"OnResultExecuted - {_name} - {_randomId}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($"OnResultExecuting - {_name} - {_randomId}");
        }
    }
}
