using Microsoft.AspNetCore.Mvc;

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
    }
}
