using org_empleados.Domain.DTOs.Roles;
using org_empleados.Domain.Models;

namespace org_empleados.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> ListAll();
        Task<Role?> ListOne(int id);
        Task<bool> Create(CreateRoleDTO role);
        Task<Role> Update(Role actualRole, Role newRole);
        Task<Role> Delete(Role role);
    }
}
