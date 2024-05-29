using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetByUsername(string username);
        Task<User> DeleteUser(string username);
    }
}
