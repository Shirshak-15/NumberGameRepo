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
            string levelValue = SharedServices.StoredValue;//stored value is used here in the guess endpoint controller 
            string playerName = SharedServices.StoredValue2;
            int hardnum = 100;
            int mednum = 50;
            int eznum = 10;
            int payloadNumber = payload.number;

            int score;
            int difference = 0;

            if (levelValue == "hard" || levelValue == "medium" || levelValue == "easy" && playerName!=null)
            {
                if (levelValue == "hard")
                {
                    if (payloadNumber == hardnum)
                    {
                        score = 200;
                        return Ok("Congrats! " + playerName + " correct on Hard! " + score + " points are rewarded.");

                    }
                    else if (payloadNumber > 1 && payloadNumber < 100)
                    {
                        difference = Math.Abs(hardnum - payloadNumber);
                        score = 200 - (2 * difference);
                        return Ok("Oops " + playerName + ", incorrect on Hard!" + score + "points are rewarded.");

                    }
                    else
                    {
                        return BadRequest("Invalid number for hard difficulty");
                    }
                }
                else if (levelValue == "medium")
                {
                    if (payloadNumber == mednum)
                    {
                        score = 100;
                        return Ok("Congrats! " + playerName + " correct on Medium!" + score + " points are rewarded.");
                    }
                    else if (payloadNumber > 1 && payloadNumber < 50)
                    {
                        difference = Math.Abs(mednum - payloadNumber);
                        score = 100 - (2 * difference);
                        return Ok("Oops " + playerName + ", incorrect on Medium! " + score + " points are rewarded.");
                    }
                    else
                    {
                        return BadRequest("Invalid number for medium difficulty");
                    }



                }
                else if (levelValue == "easy")
                {
                    if (payloadNumber == eznum)
                    {
                        score = 20;
                        return Ok("Congrats! " + playerName + " correct on easy!" + score + " points are rewarded.");
                    }
                    else if (payloadNumber > 1 && payloadNumber < 10)
                    {
                        difference = Math.Abs(eznum - payloadNumber);
                        score = 20 - (2 * difference);
                        return Ok("Oops " + playerName + ", incorrect on  Easy " + score + " points are rewarded.");
                    }
                    else
                    {
                        return BadRequest("Invalid number for easy difficulty");
                    }

                }
            }
            
                return BadRequest("Either username is not added or difficulty is invalid/not added");

            

                
            
        }
    }
}
