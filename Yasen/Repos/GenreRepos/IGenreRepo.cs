using Yasen.Dtos;

namespace Yasen.Repos.GenreRepos
{
    public interface IGenreRepo
    {
        IEnumerable<GenreDto> GetGenres();
        GenreDto GetGenre(int id);
        void DeleteGenre(int id);
        void UpdateGenre(GenreDto genreDto , int id);
        void AddGenre(GenreDto genreDto);
    }
}
