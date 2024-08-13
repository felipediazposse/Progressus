using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.AuthDtos;

namespace ProgressusWebApi.Services.AuthServices.Interfaces
{
    public interface IAuthService
    {
        Task<IActionResult?> EnviarCodigoDeVerificacion(string email);

        Task<IActionResult?> ConfirmarCorreo(CodigoDeVerificacionDto codigoDeVerificacion);

        Task<IActionResult?> ObtenerTokenCambioDeContraseña(CodigoDeVerificacionDto codigoDeVerificacion);

        Task<bool> ComprobarCodigoDeVerificacion(CodigoDeVerificacionDto codigoDeVerificacion);

        Task<IActionResult> CambiarContraseña(CambioDeContraseñaDto cambioDeContraseñaDto);
    }
}
