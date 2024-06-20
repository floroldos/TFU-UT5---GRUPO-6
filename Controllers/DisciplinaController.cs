using Microsoft.AspNetCore.Mvc;
using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
using MySolidWebApi.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace MySolidWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService = new DisciplinaService();

        private readonly IScoreService _surfScoreService = new SurfScoreService();

        private IScoreService GetScoreService(string disciplina)
        {
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

        [HttpGet()]
        [Route("")]
        public IActionResult GetDisciplina([FromQuery] string nombre)
        {
            var disciplina = _disciplinaService;
            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina.GetDisciplina(nombre));
        }

        // [HttpGet]
        // public IActionResult GetAllDisciplinas()
        // {
        //     var disciplinas = _disciplinaService.GetAllDisciplinas();
        //     return Ok(disciplinas);
        // }

        [HttpPost()]
        [Route("")]
        public IActionResult AddDisciplina([FromQuery] string nombre, [FromBody] JsonElement body)
        {
            // Check if 'modalidad' property exists
            if (!body.TryGetProperty("modalidad", out JsonElement modalidadRaw))
            {
                throw new ArgumentException("SurferId is required and must be a number.");
            }

            var modalidad = JsonSerializer.Deserialize<Modalidad>(modalidadRaw.GetRawText());
            if (modalidad == null)
            {
                throw new ArgumentException("Error deserializing modalidad.");
            }

            var disciplinaService = _disciplinaService;

            var scoreService = GetScoreService(nombre);
            if (scoreService == null)
            {
                throw new InvalidOperationException($"ScoreService not found for nombre: {nombre}");
            }

            var newDisciplina = new Disciplina(nombre, scoreService, modalidad);
            disciplinaService.AddDisciplina(newDisciplina);
            return Ok();
        }

        [HttpPut("")]
        public IActionResult UpdateDisciplina([FromQuery] string nombre, [FromBody] JsonElement body)
        {
            // Check if 'modalidad' property exists
            if (!body.TryGetProperty("modalidad", out JsonElement modalidadRaw))
            {
                throw new ArgumentException("SurferId is required and must be a number.");
            }

            var modalidad = JsonSerializer.Deserialize<Modalidad>(modalidadRaw.GetRawText());
            if (modalidad == null)
            {
                throw new ArgumentException("Error deserializing modalidad.");
            }

            var disciplinaService = _disciplinaService;

            var scoreService = GetScoreService(nombre);
            if (scoreService == null)
            {
                throw new InvalidOperationException($"ScoreService not found for nombre: {nombre}");
            }
            var newDisciplina = new Disciplina(nombre, scoreService, modalidad);
            disciplinaService.UpdateDisciplina(nombre, newDisciplina);
            return NoContent();
        }

        [HttpDelete("")]
        public IActionResult DeleteDisciplina([FromQuery] string nombre)
        {
            var disciplina = _disciplinaService;
            disciplina.DeleteDisciplina(nombre);
            return NoContent();
        }

        [HttpPost]
        [Route("addScore")]
        public IActionResult CalculateAndSaveScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = _disciplinaService;

            var result = service.CalculateAndSaveScore(name, body);
            return Ok();
            // return Ok(result);
        }

        [HttpPost("getScore")]
        public IActionResult GetScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = _disciplinaService;

            var score = service.GetScore(name, body);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

        [HttpGet("getAllScores")]
        public IActionResult GetAllScores([FromQuery] string name)
        {
            var service = _disciplinaService;

            var scores = service.GetAllScores();
            return Ok(scores);
        }

        [HttpPut("updateScore")]
        public IActionResult UpdateScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = _disciplinaService;

            service.UpdateScore(name, body);

            return NoContent();
        }

        [HttpDelete("deleteScore")]
        public IActionResult DeleteScore([FromQuery] string name, [FromBody] JsonElement body)
        {
            var service = _disciplinaService;

            service.DeleteScore(name, body);

            return NoContent();
        }

        // [HttpGet("/performance/{IDPerformance}/calculateScore")]
        // public IActionResult CalculateScore(string nombreDisciplina, int waveId, int surferId)
        // {


        //     var score = _disciplinaService.CalculateScore(nombreDisciplina, waveId, surferId);
        //     if (score == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(score);
        // }

    }

    // public class PointsRequest
    // {
    //     public int WaveId { get; set; }
    //     public int SurferId { get; set; }
    //     public double[] Scores { get; set; }
    // }
}
