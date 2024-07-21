using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using ProgressusWebApi.DataContext;
using ProgressusWebApi.Dtos.AuthDtos;
using ProgressusWebApi.Repositories.AuthRepository.IRepositories;

namespace ProgressusWebApi.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ProgressusDataContext _progressusDataContext;
        public AuthRepository(UserManager<IdentityUser> userManager, ProgressusDataContext progressusDataContext)
        {
            _userManager = userManager;
            _progressusDataContext = progressusDataContext;
        }

        public async Task<TokenConfirmacionCorreoDto?> GenerarTokenDeConfirmacion(string email)
        {

            var userToConfirm = await _userManager.FindByEmailAsync(email);
            if (userToConfirm != null)
            {
                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(userToConfirm);
                TokenConfirmacionCorreoDto token = new TokenConfirmacionCorreoDto
                {
                    Token = confirmationToken,
                    Email = email,
                    Id = userToConfirm.Id
                };
                return token;
            }
            return null;
        }
    }
}
