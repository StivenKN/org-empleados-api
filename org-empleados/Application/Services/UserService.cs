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

        public async Task<User> DeleteUser(string id)
        {
            User? user = await _userRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(user);
            return await _userRepository.Delete(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.ListAll();
        }

        public async Task<User> GetById(string id)
        {
            User? user = await _userRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(user);
            return user;
        }

        public async Task<User> UpdateUser(string id, UpdateUserDTO userDTO)
        {
            User? actualUser = await _userRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(actualUser);
            User user = userDTO.ToModelFromUpdateDTO();
            if (user.PasswordHash != null)
            {
                user.PasswordHash = Encryption.EncryptPassword(user.PasswordHash);
            }
            return await _userRepository.Update(actualUser, user);
        }
    }
}
