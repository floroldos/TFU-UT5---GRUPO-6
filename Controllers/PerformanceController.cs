using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class PerformanceController : ControllerBase
{
    private readonly IPerformanceService _performanceService;

    public PerformanceController(IPerformanceService performanceService)
    {
        _performanceService = performanceService;
    }

    [HttpPost]
    [Route("crear")]
    public ActionResult<Performance> CrearPerformance([FromBody] PerformanceRequest request)
    {
        var performance = _performanceService.CrearPerformance(request);
        return Ok(performance);
    }
}

public class PerformanceRequest
{
    public string Nombre { get; set; }
    public DateTime Fecha { get; set; }
    public Disciplina Disciplina { get; set; }
    public List<Equipo> Equipos { get; set; }
    public List<Puntaje> Puntos { get; set; }
}
