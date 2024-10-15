using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.RerservaDto;

namespace ProgressusWebApi.Services.ReservaService.cs.interfaces
{
    public interface IReservaService
    {
        Task<IActionResult> CrearReservaAsync(RerservaDto reservaDto);
        Task<IActionResult> VerificarDisponibilidadAsync(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin);
        Task<IActionResult> ObtenerReservasPorUsuarioAsync(string userId);

        // Agregar el método EliminarReserva
        Task<IActionResult> EliminarReservaAsync(string userId);
    }
}