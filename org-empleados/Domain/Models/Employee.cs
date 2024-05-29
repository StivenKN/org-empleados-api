using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int FkIdRole { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = null;
        [JsonIgnore]
        public Role? Role { get; set; } = null;
    }
}
