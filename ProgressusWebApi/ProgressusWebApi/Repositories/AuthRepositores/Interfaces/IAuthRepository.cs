using Microsoft.AspNetCore.Identity;
using ProgressusWebApi.Dtos.AuthDtos;


namespace ProgressusWebApi.Repositories.AuthRepository.IRepositories
{

    public interface IAuthRepository
    {
        Task<TokenConfirmacionCorreoDto?> GenerarTokenDeConfirmacion(string email);
    }
}
