using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using org_empleados.Data;
using org_empleados.Interfaces;
using org_empleados.Models;

namespace org_empleados.Repositories
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Create(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Role> Delete(Role role)
        {
            role.DeletedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<List<Role>> ListAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> ListOne(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Role> Update(Role actualRole, Role newRole)
        {
            actualRole.Name = newRole.Name;
            actualRole.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return actualRole;
        }
    }
}
