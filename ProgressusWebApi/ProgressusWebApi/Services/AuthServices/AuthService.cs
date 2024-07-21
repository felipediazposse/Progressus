using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using ProgressusWebApi.Dtos.AuthDtos;
using ProgressusWebApi.Repositories.AuthRepository.IRepositories;
using ProgressusWebApi.Services.AuthServices.Interfaces;
using ProgressusWebApi.Services.EmailServices.Interfaces;

namespace ProgressusWebApi.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        readonly IMemoryCache _memoryCache;
        readonly IEmailSenderService _emailSenderService;
        readonly IAuthRepository _usuarioRepository;

        public AuthService(IMemoryCache memoryCache, IEmailSenderService emailSenderService, IAuthRepository usuarioRepository)
        {
            _memoryCache = memoryCache;
            _emailSenderService = emailSenderService;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<bool> EnviarCodigoDeVerificacionDeCorreo(string correo)
        {
            var codigoVerificacion = new Random().Next(1000, 9999).ToString();
            _emailSenderService.SendEmail("Código de confirmación", codigoVerificacion.ToString(), correo);
            _memoryCache.Set(correo, codigoVerificacion, TimeSpan.FromMinutes(5));
            bool result = true;
            return result;
        }

        public async Task<TokenConfirmacionCorreoDto?> ConfirmarCorreo(ConfirmacionCorreoDto confirmacionCorreo)
        {
            if (_memoryCache.TryGetValue(confirmacionCorreo.Email, out string codigoVerificacion))
            {
                if (codigoVerificacion == confirmacionCorreo.Codigo)
                {
                    _memoryCache.Remove(confirmacionCorreo.Email); // Eliminar el código de la caché
                    return await _usuarioRepository.GenerarTokenDeConfirmacion(confirmacionCorreo.Email);
                }
                else return null;
            }
            else return null;
        }
    }
}
