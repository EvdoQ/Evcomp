using Evcomp.API.Models;
using Evcomp.Business.Dto;
using Evcomp.Business.IServices;
using Evcomp.Data.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Evcomp.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtService _jwtService;

        public AuthService(IAuthRepository authRepository, JwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<UserEntity> Register(RegisterRequestDTO model)
        {
            var existingUser = await _authRepository.GetUserByUserNameAsync(model.UserName);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with that username already exists.");
            }

            UserEntity user = new UserEntity
            {
                UserName = model.UserName,
                FirstName = model.Name,
                Role = model.Role,

            };

            var passHash = new PasswordHasher<UserEntity>().HashPassword(user, model.Password);
            user.PasswordHash = passHash;

            await _authRepository.Add(user);
            return user;
        }

        public async Task<string> Login(LoginRequestDTO model)
        {
            var user = await _authRepository.GetUserByUserNameAsync(model.UserName);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var result = new PasswordHasher<UserEntity>()
                .VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (result == PasswordVerificationResult.Success)
            {
                return _jwtService.GenerateToken(user);
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
        }
    }

}
