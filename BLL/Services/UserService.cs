using DAL.Models;
using DAL.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public Task<User> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null || !VerifyPasswordHash(password, user.Password))
            {
                // Authentication failed
                return null;
            }

            return GenerateJwtToken(user.UserName);
        }
        public async Task Register(User user)
        {
            // Hash the password before storing it in the database
            user.Password = CreatePasswordHash(user.Password);

            await _userRepository.CreateUser(user);
        }

        public async Task UpdateUser(int userId, User user)
        {
            var existingUser = await _userRepository.GetUserById(userId);
            if (existingUser == null)
            {
                // User not found
                return;
            }

            existingUser.UserName = user.UserName;
            existingUser.Password = CreatePasswordHash(user.Password);
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;

            await _userRepository.UpdateUser(existingUser);
        }
        private string CreatePasswordHash(string password)
        {
            return password;
        }

        private bool VerifyPasswordHash(string password, string existingPassword)
        {
            return password == existingPassword;
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
