using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using ProgressusWebApi.Dtos.AuthDtos;

using ProgressusWebApi.Services.AuthServices.Interfaces;
using ProgressusWebApi.Services.EmailServices.Interfaces;

namespace ProgressusWebApi.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        readonly IMemoryCache _memoryCache;
        readonly IEmailSenderService _emailSenderService;
        readonly UserManager<IdentityUser> _userManager;

        public AuthService(IMemoryCache memoryCache, IEmailSenderService emailSenderService, UserManager<IdentityUser> userManager)
        {
            _memoryCache = memoryCache;
            _emailSenderService = emailSenderService;
            _userManager = userManager;
        }
        public async Task<IActionResult> EnviarCodigoDeVerificacion(string correo)
        {
            if (_memoryCache.TryGetValue(correo, out string codigoVerificacionExistente))
            {
                return new BadRequestObjectResult("El código para ese email ya se generó y se debe esperar 2 minutos.");
            }

            var codigoVerificacion = new Random().Next(1000, 9999).ToString();
            await _emailSenderService.SendEmail("Código de confirmación", codigoVerificacion, correo);
            _memoryCache.Set(correo, codigoVerificacion, TimeSpan.FromMinutes(2));

            return new OkObjectResult("El código de verificación se generó correctamente.");
        }

        public async Task<IActionResult?> ConfirmarCorreo(CodigoDeVerificacionDto codigoDeVerificacion)
        {
            try
            {
                if (ComprobarCodigoDeVerificacion(codigoDeVerificacion).Result == false)
                {
                    return null;
                }

                IdentityUser? usuarioAConfirmar = await _userManager.FindByEmailAsync(codigoDeVerificacion.Email);
                if (usuarioAConfirmar == null)
                {
                    return null;
                }

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(usuarioAConfirmar);
                var result = await _userManager.ConfirmEmailAsync(usuarioAConfirmar, confirmationToken);
                if (!result.Succeeded)
                {
                    return null; // Fallo en la confirmación del correo
                }

                return new OkObjectResult("Email de usuario confirmado");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<IActionResult?> ObtenerTokenCambioDeContraseña(CodigoDeVerificacionDto codigoDeVerificacion)
        {
            try
            {
                if (ComprobarCodigoDeVerificacion(codigoDeVerificacion).Result == false)
                {
                    return null;
                }

                IdentityUser? usuarioCambioContraseña = await _userManager.FindByEmailAsync(codigoDeVerificacion.Email);
                if (usuarioCambioContraseña == null)
                {
                    return null;
                }
                CambioDeContraseñaDto cambioDeContraseña = new CambioDeContraseñaDto()
                {
                    Token = await _userManager.GeneratePasswordResetTokenAsync(usuarioCambioContraseña),
                    Email = codigoDeVerificacion.Email,
                };

                return new OkObjectResult(cambioDeContraseña);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ComprobarCodigoDeVerificacion(CodigoDeVerificacionDto codigoDeVerificacion)
        {
            try
            {
                if (!_memoryCache.TryGetValue(codigoDeVerificacion.Email, out string codigoDeVerificacionEnCache))
                {
                    return false;
                }

                if (codigoDeVerificacionEnCache != codigoDeVerificacion.Codigo)
                {
                    return false;
                }

                _memoryCache.Remove(codigoDeVerificacion.Email); // Eliminar el código de la caché
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
