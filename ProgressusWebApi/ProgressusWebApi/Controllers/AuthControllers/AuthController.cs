using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.AuthDtos;
using ProgressusWebApi.Services.AuthServices.Interfaces;

namespace ProgressusWebApi.Controllers.AuthControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _usuarioService;

        public AuthController(IAuthService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("EnviarCodigoDeVerificacion")]
        public async Task<IActionResult> EnviarCodigoDeVerificacionDeCorreo([FromBody] CorreoRequestDto correo)
        {
            return await _usuarioService.EnviarCodigoDeVerificacion(correo.Email);
        }

        [HttpPost("ComprobarCodigoDeCambioContraseña")]
        public async Task<IActionResult> ComprobarCodigoDeCambioContraseña([FromBody] CodigoDeVerificacionDto codigoDeVerificacion)
        {
            return await _usuarioService.ObtenerTokenCambioDeContraseña(codigoDeVerificacion);
        }


        [HttpPost("ConfirmarCorreo")]
        public async Task<IActionResult> ConfirmarCorreo([FromBody] CodigoDeVerificacionDto codigoDeVerificacion)
        {
            return await _usuarioService.ConfirmarCorreo(codigoDeVerificacion);
        }
    }

}
