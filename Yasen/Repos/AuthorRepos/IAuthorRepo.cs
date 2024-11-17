using Yasen.Dtos;
using Yasen.Models;

namespace Yasen.Repos.AuthorRepos
{
    public interface IAuthorRepo
    {
        IEnumerable<AuthorDto> GetAll();
        AuthorDto GetById(int id);
        void AddAuthor(AuthorDto authorDto);
        void UpdateAuthor(AuthorDto authorDto , int id);
        void DeleteAuthor(int id);
    }
}
