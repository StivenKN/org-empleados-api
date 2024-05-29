using org_empleados.Application.Interfaces;
using org_empleados.Domain.Models;

namespace org_empleados.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _userRepository = repository;

        public async Task<User> DeleteUser(string username)
        {
            User? user = await _userRepository.ListOne(username);
            ArgumentNullException.ThrowIfNull(user);
            return await _userRepository.Delete(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.ListAll();
        }

        public async Task<User> GetByUsername(string username)
        {
            User? user = await _userRepository.ListOne(username);
            ArgumentNullException.ThrowIfNull(user);
            return user;
        }
    }
}
