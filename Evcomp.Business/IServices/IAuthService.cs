using Evcomp.API.Models;
using Evcomp.Business.Dto;

namespace Evcomp.Business.IServices
{
    public interface IAuthService
    {
        Task<UserEntity> Register(RegisterRequestDTO model);
        Task<LoginResponseDTO> Login(LoginRequestDTO model);
    }
}
