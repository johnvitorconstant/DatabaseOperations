using System.ComponentModel.DataAnnotations;

namespace DatabaseOperations.Models
{
    public class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
