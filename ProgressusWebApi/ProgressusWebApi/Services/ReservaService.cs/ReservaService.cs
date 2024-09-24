using ProgressusWebApi.Dtos.RerservaDto;
//using ProgressusWebApi.Services.ReservaService.Interfaces;
using ProgressusWebApi.DataContext;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.DataContext;
using ProgressusWebApi.Dtos.RerservaDto;
using ProgressusWebApi.Models.RerservasModels;
using ProgressusWebApi.Services.ReservaService.cs.interfaces;
using ProgressusWebApi.Models.RerservasModels;  // Asegúrate de usar el espacio de nombres correcto

namespace ProgressusWebApi.Services.ReservaServices
{
    public class ReservaService : IReservaService
    {
        private readonly ProgressusDataContext _context;

        public ReservaService(ProgressusDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CrearReservaAsync(RerservaDto reservaDto)
        {
            // Lógica para crear una reserva
            var existeConflicto = _context.Reservas
                .Any(r => r.FechaReserva == reservaDto.Fecha &&
                          r.HoraInicio < reservaDto.HoraFin &&
                          r.HoraFin > reservaDto.HoraInicio);

            if (existeConflicto)
            {
                return new BadRequestObjectResult("El horario seleccionado ya está reservado.");
            }

            var reserva = new ReservaTurno
            {
                UserId = reservaDto.UserId,
                FechaReserva = reservaDto.Fecha,
                HoraInicio = reservaDto.HoraInicio,
                HoraFin = reservaDto.HoraFin,
                Confirmada = true // Confirmada automáticamente
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Reserva creada exitosamente.");
        }

        public async Task<IActionResult> VerificarDisponibilidadAsync(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            // Lógica para verificar disponibilidad
            var existeConflicto = _context.Reservas
                .Any(r => r.FechaReserva == fecha && r.HoraInicio < horaFin && r.HoraFin > horaInicio);

            return new OkObjectResult(!existeConflicto);
        }

        public async Task<IActionResult> ObtenerReservasPorUsuarioAsync(string userId)
        {
            var reservas = _context.Reservas
                .Where(r => r.UserId == userId)
                .ToList();

            return new OkObjectResult(reservas);
        }
    }
}
