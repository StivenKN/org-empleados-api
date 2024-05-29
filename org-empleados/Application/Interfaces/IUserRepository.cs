using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> ListAll();
        Task<User?> ListOne(string username);
        Task<User> Delete(User user);
    }
}
