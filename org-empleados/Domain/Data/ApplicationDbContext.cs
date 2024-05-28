using Microsoft.EntityFrameworkCore;
using org_empleados.Domain.Models;

namespace org_empleados.Domain.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Role>()
                .Property(e => e.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<Role>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql(null);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql(null);

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .Property(e => e.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<User>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql(null);


            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.FkIdRole);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.FkIdRole);
        }
    }
}
