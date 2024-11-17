using Yasen.Dtos;
using Yasen.Models;

namespace Yasen.Repos.BookRepos
{
    public interface IBookRepo
    {
        IEnumerable<BookDto> GetBooks();
        BookDto GetBook(int id);
        void UpdateBook(BookDto bookDto,int id);
        void AddBook(BookDto bookDto);
        void DeleteBook(int id);
    }
}
