using System.ComponentModel.DataAnnotations;

namespace Yasen.Dtos
{
    public class AuthorDto
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        
    }
}
