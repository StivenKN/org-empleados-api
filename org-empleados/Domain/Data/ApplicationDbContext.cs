using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using org_empleados.Domain.Models;

namespace org_empleados.Domain.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql(null);

            modelBuilder.Entity<User>()
                .Property(e => e.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<User>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql(null);
        }
    }
}
