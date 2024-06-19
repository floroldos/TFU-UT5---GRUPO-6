using Microsoft.AspNetCore.Mvc;
using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
using System.Collections.Generic;

namespace MySolidWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpGet("{nombre}")]
        public IActionResult GetDisciplina(string nombre)
        {
            var disciplina = _disciplinaService.GetDisciplina(nombre);
            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina);
        }

        [HttpGet]
        public IActionResult GetAllDisciplinas()
        {
            var disciplinas = _disciplinaService.GetAllDisciplinas();
            return Ok(disciplinas);
        }

        [HttpPost]
        public IActionResult AddDisciplina([FromBody] Disciplina disciplina)
        {
            _disciplinaService.AddDisciplina(disciplina);
            return CreatedAtAction(nameof(GetDisciplina), new { nombre = disciplina.Nombre }, disciplina);
        }

        [HttpPut("{nombre}")]
        public IActionResult UpdateDisciplina(string nombre, [FromBody] Disciplina disciplina)
        {
            _disciplinaService.UpdateDisciplina(nombre, disciplina);
            return NoContent();
        }

        [HttpDelete("{nombre}")]
        public IActionResult DeleteDisciplina(string nombre)
        {
            _disciplinaService.DeleteDisciplina(nombre);
            return NoContent();
        }

        [HttpPost("{nombreDisciplina}/addPoints")]
        public IActionResult AddPoints(string nombreDisciplina, [FromBody] PointsRequest request)
        {
            _disciplinaService.AddPoints(nombreDisciplina, request.WaveId, request.SurferId, request.Scores);
            return NoContent();
        }

        [HttpGet("/performance/{IDPerformance}/calculateScore")]
        public IActionResult CalculateScore(string nombreDisciplina, int waveId, int surferId)
        {

            
            var score = _disciplinaService.CalculateScore(nombreDisciplina, waveId, surferId);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

    }

    public class PointsRequest
    {
        public int WaveId { get; set; }
        public int SurferId { get; set; }
        public double[] Scores { get; set; }
    }
}
