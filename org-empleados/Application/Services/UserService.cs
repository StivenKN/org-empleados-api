using Microsoft.IdentityModel.Tokens;
using org_empleados.Application.Interfaces;
using org_empleados.Application.Lib;
using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;
using org_empleados.Mappers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace org_empleados.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _userRepository = repository;
        private readonly string _secret = "Sivesestomedescubristeahoraporfavornomehackees";

        public async Task<bool> CreateUser(CreateUserDTO userDTO)
        {
            userDTO.Password = Encryption.EncryptPassword(userDTO.Password);
            User user = userDTO.ToModelFromCreateDTO();
            return await _userRepository.Create(user);
        }

        public async Task<User> DeleteUser(int id)
        {
            User? user = await _userRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(user);
            return await _userRepository.Delete(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.ListAll();
        }

        public async Task<User> GetById(int id)
        {
            User? user = await _userRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(user);
            return user;
        }

        public async Task<SecurityToken> Login(LoginUserDTO userDTO)
        {
            User user = userDTO.ToModelFromLoginDTO();

            ArgumentNullException.ThrowIfNull(user.UserName);
            ArgumentNullException.ThrowIfNull(user.Password);

            User databaseUser = await _userRepository.Login(user.UserName);

            ArgumentNullException.ThrowIfNull(databaseUser.Password);

            bool resultHash = Encryption.ComparePassword(user.Password, databaseUser.Password);

            if (resultHash != true)
            {
                throw new ArgumentException("Las contraseñas no coinciden");
            }

            List<Claim> claims = [new Claim(ClaimTypes.Name, user.UserName)];
            var identity = new ClaimsIdentity(claims, "ApplicationCookie");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)), SecurityAlgorithms.HmacSha256)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.CreateToken(tokenDescriptor);
        }

        public async Task<User> UpdateUser(int id, UpdateUserDTO userDTO)
        {
            User? actualUser = await _userRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(actualUser);
            User user = userDTO.ToModelFromUpdateDTO();
            if (user.Password != null)
            {
                user.Password = Encryption.EncryptPassword(user.Password);
            }
            return await _userRepository.Update(actualUser, user);
        }
    }
}
