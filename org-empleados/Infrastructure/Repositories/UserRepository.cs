using Microsoft.EntityFrameworkCore;
using org_empleados.Application.Interfaces;
using org_empleados.Domain.Data;
using org_empleados.Domain.Models;

namespace org_empleados.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> Delete(User user)
        {
            user.DeletedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> ListAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> ListOne(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<User> Login(string username)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(d => d.UserName == username);
            ArgumentNullException.ThrowIfNull(user, "El usuario no existe");
            return user;
        }

        public async Task<User> Update(User actualUser, User newUser)
        {
            actualUser.UserName = newUser.UserName ?? actualUser.UserName;
            actualUser.Password = newUser.Password ?? actualUser.Password;
            actualUser.FkIdRole = newUser.FkIdRole ?? actualUser.FkIdRole;
            await _context.SaveChangesAsync();
            return actualUser;
        }
    }
}
