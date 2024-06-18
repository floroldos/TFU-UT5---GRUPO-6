using System;
using System.Collections.Generic;
using MySolidWebApi.Services;

public class PerformanceService : IPerformanceService
{
    private readonly Database<Performance> _database;

    public PerformanceService()
    {
        _database = Database<Performance>.Instance;
    }

    public Performance CrearPerformance(PerformanceRequest request)
    {
        var performance = new Performance
        {
            Nombre = request.Nombre,
            Fecha = request.Fecha,
            Disciplina = request.Disciplina,
            Equipos = request.Equipos,
            Puntos = request.Puntos
        };

        _database.AddItem(performance);

        return performance;
    }
}
