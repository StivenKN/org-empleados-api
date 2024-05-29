using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = null;
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; } = [];
        [JsonIgnore]
        public ICollection<User> Users { get; set; } = [];
    }
}
