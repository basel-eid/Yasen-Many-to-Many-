using System.ComponentModel.DataAnnotations;

namespace Yasen.Dtos
{
    public class GenreDto
    {
        [Required]
        public string Name { get; set; }
        
    }
}
