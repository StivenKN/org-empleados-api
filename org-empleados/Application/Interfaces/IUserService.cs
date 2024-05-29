using org_empleados.Domain.DTOs.Roles;
using org_empleados.Domain.DTOs.Users;
using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<bool> CreateUser(CreateUserDTO userDTO);
        Task<User> UpdateUser(int id, UpdateUserDTO userDTO);
        Task<User> DeleteUser(int id);
    }
}
