using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; } = [];
        [JsonIgnore]
        public ICollection<User> Users { get; set; } = [];
    }
}
