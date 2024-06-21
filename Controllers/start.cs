using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using numguess.Models.Domains;


namespace numguess.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class start : ControllerBase
    {
        [HttpPost]
        public IActionResult fetchDiffuculty([FromBody] difficulty payload)
        {
            string levelValue = payload.level;
            SharedServices.StoredValue = payload.level; //this value gets stored in StoredValue that can be used in guess controller
            SharedServices.StoredValue2 = payload.playerName;
            
            if (levelValue == "hard")
            {
                return Ok();
            }
            else if (levelValue == "medium")
            {
                return Ok();
            }
            else if (levelValue == "easy")
            {
                return Ok();
            }
            else
            {
                return BadRequest("chose between easy||medium||hard");
            }
        }

    }
}
