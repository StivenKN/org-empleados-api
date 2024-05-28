using System.ComponentModel.DataAnnotations.Schema;

namespace org_empleados.Domain.Models
{
    public class User
    {
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int FkIdRole { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public required Role Role { get; set; }
    }
}
