using Microsoft.AspNetCore.Mvc;
using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
using System.Collections.Generic;

namespace MySolidWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurfScoreController : ControllerBase
    {
        private readonly ISurfScoreService _surfScoreService;

        public SurfScoreController(ISurfScoreService surfScoreService)
        {
            _surfScoreService = surfScoreService;
        }

        [HttpPost]
        [Route("calculate")]
        public IActionResult CalculateAndSaveScore([FromBody] SurfScoreRequest request)
        {
            if (request == null || request.Scores == null || request.Scores.Length != 5)
            {
                return BadRequest("Five scores are required.");
            }

            var result = _surfScoreService.CalculateAndSaveScore(request.WaveId, request.SurferId, request.Scores);
            return Ok(result);
        }

        [HttpGet("{waveId}/{surferId}")]
        public IActionResult GetScore(int waveId, int surferId)
        {
            var score = _surfScoreService.GetScore(waveId, surferId);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

        [HttpGet]
        public IActionResult GetAllScores()
        {
            var scores = _surfScoreService.GetAllScores();
            return Ok(scores);
        }

        [HttpPut("{waveId}/{surferId}")]
        public IActionResult UpdateScore(int waveId, int surferId, [FromBody] SurfScoreRequest request)
        {
            if (request == null || request.Scores == null || request.Scores.Length != 5)
            {
                return BadRequest("Five scores are required.");
            }

            _surfScoreService.UpdateScore(waveId, surferId, request.Scores);
            return NoContent();
        }

        [HttpDelete("{waveId}/{surferId}")]
        public IActionResult DeleteScore(int waveId, int surferId)
        {
            _surfScoreService.DeleteScore(waveId, surferId);
            return NoContent();
        }
    }

    public class SurfScoreRequest
    {
        public int WaveId { get; set; }
        public int SurferId { get; set; }
        public double[] Scores { get; set; }
    }
}
