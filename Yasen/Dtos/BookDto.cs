using System.ComponentModel.DataAnnotations;

namespace Yasen.Dtos
{
    public class BookDto
    {
        [Required(ErrorMessage = "The Title is required")]
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public List<int> GenreId { get; set; }
        public List<int> AuthorId { get; set; }
        public List<string>? Authors { get; set; }
        public List<string>? Genres { get; set; }
        
    }
}
