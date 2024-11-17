using Yasen.Data;
using Yasen.Dtos;
using Yasen.Models;

namespace Yasen.Repos.GenreRepos
{
    public class GenreRepo : IGenreRepo
    {
        private readonly DataContext _context;
        public GenreRepo(DataContext context)
        {
            _context = context;
        }
        public void AddGenre(GenreDto genreDto)
        {
            var a = new Genre
            {
                Name = genreDto.Name,
               
            };
            _context.Genres.Add(a);
            _context.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            var genre = _context.Genres.FirstOrDefault(a => a.Id == id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            return;
        }

        public GenreDto GetGenre(int id)
        {
            var genre = _context.Genres.FirstOrDefault(a => a.Id == id);
            return new GenreDto
            {
                Name = genre.Name,
                
            };
        }

        public IEnumerable<GenreDto> GetGenres()
        {
            var genre = _context.Genres.Select(x => new GenreDto
            {
                Name = x.Name,
                
            }).ToList();
            return genre;
        }

        public void UpdateGenre(GenreDto genreDto, int id)
        {
            var x = new Genre
            {
                Name = genreDto.Name,
               
            };
            _context.Genres.Update(x);
            _context.SaveChanges();
        }
    }
}
