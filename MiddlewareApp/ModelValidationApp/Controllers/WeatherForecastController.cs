using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get(string id, bool? isTest)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(id)) errors.Add("id is required");
            if (!isTest.HasValue) errors.Add("isTest is required");

            if (errors.Count > 0) return BadRequest(errors);

            return $"Id : {id} - isTest : {isTest}";
        }

        [HttpGet("modelstate")]
        public ActionResult<string> ModelStateGet(string id, bool? isTest)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(id)) ModelState.AddModelError(nameof(id), "id is required");
            if (!isTest.HasValue) ModelState.AddModelError(nameof(isTest), "isTest is required");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return $"Id : {id} - isTest : {isTest}";
        }

        [HttpGet("required")]
        public ActionResult<string> Required([Required] string id, [Required] bool? isTest)
        {
            return $"Id : {id} - isTest : {isTest}";
        }

        [HttpPost("mydata")]
        public ActionResult<string> MyDataPost([FromBody] MyData myData)
        {
            return $"Name : {myData.Name} - Age : {myData.Age} - Email : {myData.Email} - Phone : {myData.Phone}";
        }

        [HttpPost("myobject")]
        public ActionResult<string> MyObjectPost([FromBody] MyObject myObject)
        {
            return $"Name : {myObject.Name} - Age : {myObject.Age} - Email : {myObject.Email} - Phone : {myObject.Phone}";
        }
    }
}
