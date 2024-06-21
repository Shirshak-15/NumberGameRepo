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
            if (levelValue=="hard")
            {
                return Ok("you chose " + levelValue + " difficulty");
            }
            else if(levelValue=="medium")
            {
                return Ok("you chose " + levelValue + " difficulty");
            }
            else
            {
                return Ok("you chose " + levelValue + " difficulty");
            }
        }

    }
}
