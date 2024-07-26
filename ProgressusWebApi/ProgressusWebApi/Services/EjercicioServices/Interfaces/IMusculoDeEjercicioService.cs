using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.EjercicioDtos.EjercicioDto;
using ProgressusWebApi.Models.EjercicioModels;

namespace ProgressusWebApi.Services.EjercicioServices.Interfaces
{
    public interface IMusculoDeEjercicioService
    {
        Task<IActionResult> AgregarMusculoAEjercicio(AgregarQuitarMusculoAEjercicioDto agregarQuitarMusculoAEjercicioDto);
        Task<IActionResult> QuitarMusculoAEjercicio(AgregarQuitarMusculoAEjercicioDto agregarQuitarMusculoAEjercicioDto);
    }
}
