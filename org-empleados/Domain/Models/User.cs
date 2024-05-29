using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace org_empleados.Domain.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required, MinLength(8)]
        public string? Password { get; set; }
        [Required]
        public int? FkIdRole { get; set; } = 2;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = null;
        [JsonIgnore]
        public Role? Role { get; set; } = null;
    }
}
