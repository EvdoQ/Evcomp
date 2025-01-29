using Evcomp.API.Data;
using Evcomp.API.Models;
using Evcomp.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Evcomp.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _db;
        public AuthRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Add(UserEntity user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<UserEntity> GetUserByUserNameAsync(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}
