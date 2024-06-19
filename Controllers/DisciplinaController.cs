using Microsoft.AspNetCore.Mvc;
using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
using MySolidWebApi.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace MySolidWebApi.Controllers
{
    [ApiController]
    [Route("api/disciplina")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IScoreService _surfScoreService;

        public DisciplinaController()
        {
            _surfScoreService = new SurfScoreService();
        }

        private IScoreService GetController(string disciplina){
            switch (disciplina)
            {
                case "Surf":
                    return _surfScoreService;
                    break;
                default:
                    break;
            }
            return null;
        }

        [HttpPost]
        [Route("addScore")]
        public IActionResult CalculateAndSaveScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = GetController(name);

            var result = service.CalculateAndSaveScore(body);
            return Ok(result);
        }

        [HttpPost("getScore")]
        public IActionResult GetScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = GetController(name);

            var score = service.GetScore(body);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

        [HttpGet("getAllScores")]
        public IActionResult GetAllScores([FromQuery] string name)
        {
            var service = GetController(name);

            var scores = service.GetAllScores();
            return Ok(scores);
        }

        [HttpPut("updateScore")]
        public IActionResult UpdateScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = GetController(name);

            service.UpdateScore(body);

            return NoContent();
        }

        [HttpDelete("deleteScore")]
        public IActionResult DeleteScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = GetController(name);

            service.DeleteScore(body);

            return NoContent();
        }
    }
}
