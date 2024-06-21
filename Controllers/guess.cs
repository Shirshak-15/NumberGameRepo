using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using numguess.Models.Domains;
using System.Diagnostics.Eventing.Reader;

namespace numguess.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class guess : ControllerBase
    {
        [HttpPost]
        public IActionResult guessthenumber([FromBody] guessednum payload)
        {
            string levelValue = SharedServices.StoredValue;//stored value is used in the guess endpoint controller 
            int hardnum = 100;
            int mednum = 50;
            int eznum = 10;
            int payloadNumber = payload.number;

            if (levelValue == "hard")
            {
                if (payloadNumber == hardnum)
                {
                    return Ok("correctOnHard");

                }
                else
                {
                    return BadRequest("incorrect");
                }
            }
            else if (levelValue == "medium")
            {
                if (payloadNumber == mednum)
                {
                    return Ok("correctOnMedium");
                }
                else
                {
                    return BadRequest("incorrect");
                }



            }
            else if (levelValue == "easy")
            {
                if (payloadNumber == eznum)
                {
                    return Ok("correctOnEasy");
                }
                else {
                    return BadRequest("incorrect");
                }
            }
            return BadRequest("not a number");
        }
    }
}
