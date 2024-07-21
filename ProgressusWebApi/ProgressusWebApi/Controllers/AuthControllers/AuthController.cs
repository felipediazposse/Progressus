using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> EnviarCodigoDeVerificacion([FromBody] CorreoRequestDto correo)
        {
            _usuarioService.EnviarCodigoDeVerificacionDeCorreo(correo.Email);
            return Ok();
        }

        [HttpPost("confirmarCorreo")]
        public async Task<IActionResult> ConfirmarCorreo([FromBody] ConfirmacionCorreoDto confirmacionCorreo)
        {
            var token = await _usuarioService.ConfirmarCorreo(confirmacionCorreo);

            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return BadRequest("Código de verificación incorrecto.");
            }
        }
    }

}
