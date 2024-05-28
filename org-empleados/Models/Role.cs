using System.ComponentModel.DataAnnotations.Schema;

namespace org_empleados.Models
{
    public class Role
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<Employee> Employees { get; set; }
        public required ICollection<User> Users { get; set; }
    }
}
