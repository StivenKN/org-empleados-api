using org_empleados.Models;

namespace org_empleados.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> ListAll();
        Task<Role?> ListOne(int id);
        Task<bool> Create(Role role);
        Task<Role> Update(Role actualRole, Role newRole);
        Task<Role> Delete(Role role);
    }
}
