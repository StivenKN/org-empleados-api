using org_empleados.Application.Interfaces;
using org_empleados.Application.Lib;
using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;
using org_empleados.Infrastructure.Repositories;
using org_empleados.Mappers;

namespace org_empleados.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _userRepository = repository;

        public async Task<bool> CreateUser(CreateUserDTO userDTO)
        {
            userDTO.Password = Encryption.EncryptPassword(userDTO.Password);
            User user = UserMappers.CreateUserFromDTO(userDTO);
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

        public Task<string> Login(LoginUserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUser(int id, UpdateUserDTO userDTO)
        {
            User? actualUser = await _userRepository.ListOne(id);
            ArgumentNullException.ThrowIfNull(actualUser);
            User user = UserMappers.UpdateUserFromDTO(userDTO);
            if (user.Password != null)
            {
                user.Password = Encryption.EncryptPassword(user.Password);
            }
            return await _userRepository.Update(actualUser, user);
        }
    }
}
