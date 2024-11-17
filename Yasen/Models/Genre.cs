using System.ComponentModel.DataAnnotations;

namespace Yasen.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
