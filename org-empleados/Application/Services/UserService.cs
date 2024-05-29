using org_empleados.Application.Interfaces;
using org_empleados.Application.Lib;
using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;
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

        public Task<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id, UpdateUserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
