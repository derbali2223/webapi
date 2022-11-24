
using Microsoft.AspNetCore.Mvc;

namespace Exercices10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ex1Controller : ControllerBase
    {
    
        [HttpGet] 
        [Route("test")]
        public IActionResult sayHello()
        {
            return Ok("Bonjour les amis");
        }


        [HttpGet("{from}/{temperature}")]
        public IActionResult convertTemp(string from, int temperature)
        {
            if(from.ToLower() == "fahrenheit") // conversionn  vers celsius
                return Ok((int) ((5*(temperature - 32))/9) + " Celsius");
            else if (from.ToLower() =="celsius")// conversionn  vers fahrenheit
                return Ok((int)((9 * temperature + 160) / 5) + " Fahrenheit");
            return BadRequest("Attention ! vérifier les entrées /to/temperature");
        }

        [HttpGet]
        public IActionResult convertTemp2([FromQuery(Name ="from")] string from, [FromQuery(Name = "temperature")] int temperature)
        {
            if (from.ToLower() == "fahrenheit") // conversionn  vers celsius
                return Ok("Service 2, " + (int)((5 * (temperature - 32)) / 9) + " Celsius");
            else if (from.ToLower() == "celsius")// conversionn  vers fahrenheit
                return Ok("Service 2, " + (int)((9 * temperature + 160) / 5) + " Fahrenheit");
            return BadRequest("Service 2, Attention ! vérifier les entrées /to/temperature");
        }

    }
}
