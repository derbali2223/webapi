using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercices10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ex2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult generateRandomTemp()
        {
            var today = new DateTime(2022, 7, 22);//DateTime.Now;
           
            if(today >= new DateTime(today.Year, 9, 22) && today <= new DateTime(today.Year, 12, 21))
            {
                return Ok("C'est l'automne, Il fait " + new Random().Next(-10, 15));
            }
            if (today >= new DateTime(today.Year, 3, 22) && today <= new DateTime(today.Year, 6, 21))
            {
                return Ok("C'est le printemps, Il fait " + new Random().Next(5, 25));
            }
            if (today >= new DateTime(today.Year, 6, 22) && today <= new DateTime(today.Year, 9, 21))
            {
                return Ok("C'est l'été, Il fait " + new Random().Next(10, 35));
            }
            if (today >= new DateTime(today.Year, 12, 22) || today <= new DateTime(today.Year, 3, 21))
            {
                return Ok("C'est l'hiver, Il fait " + new Random().Next(-20, 15));
            }
            return BadRequest("Hors plage horaire");
        }

        
    }
}
