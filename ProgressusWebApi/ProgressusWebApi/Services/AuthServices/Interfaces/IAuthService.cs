using ProgressusWebApi.Dtos.AuthDtos;

namespace ProgressusWebApi.Services.AuthServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> EnviarCodigoDeVerificacionDeCorreo(string email);

        Task<TokenConfirmacionCorreoDto?> ConfirmarCorreo(ConfirmacionCorreoDto confirmacionCorreo);

    }
}
