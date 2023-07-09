using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ModelBindingApp
{
    public class MyComplexType
    {
        [FromQuery]
        public int Id { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string Language { get; set; }

        [BindProperty(SupportsGet = true, Name = "isBool")]
        public bool IsBool { get; set; }

        public int[] Marks { get; set; }

        public Dictionary<string,int> Actions { get; set; }
    }
}
