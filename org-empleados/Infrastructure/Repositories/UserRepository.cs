using Microsoft.EntityFrameworkCore;
using org_empleados.Application.Interfaces;
using org_empleados.Domain.Data;
using org_empleados.Domain.Models;

namespace org_empleados.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> Delete(User user)
        {
            user.DeletedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> ListAll()
        {
            return await _context.Users.Where(d => d.DeletedAt == null).ToListAsync();
        }

        public async Task<User?> ListOne(string username)
        {
            var normalizedUsername = username.ToUpperInvariant();
            return await _context.Users.FirstOrDefaultAsync(d => d.NormalizedUserName == normalizedUsername);
        }
    }
}
