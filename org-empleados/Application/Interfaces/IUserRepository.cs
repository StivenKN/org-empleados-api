using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> ListAll();
        Task<User?> ListOne(int id);
        Task<bool> Create(User user);
        Task<User> Update(User actualUser, User newUser);
        Task<User> Delete(User user);
        Task<User> Login(string username);
    }
}
