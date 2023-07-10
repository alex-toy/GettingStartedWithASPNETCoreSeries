using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FilterApp.Filters
{
    public class ResourceFilterAttribute : Attribute, IResourceFilter, IOrderedFilter
    {
        private readonly string _name;

        public int Order { get; set; }

        public ResourceFilterAttribute(string name, int order = 0)
        {
            this._name = name;
            Order = order;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"OnResourceExecuted {_name} - order : {Order}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"OnResourceExecuting {_name} - order : {Order}");
        }
    }
}
