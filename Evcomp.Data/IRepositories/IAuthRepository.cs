using Evcomp.API.Models;

namespace Evcomp.Data.IRepositories
{
    public interface IAuthRepository
    {
        Task Add(UserEntity user);
        Task<UserEntity> GetUserByUserNameAsync(string username);
    }
}
