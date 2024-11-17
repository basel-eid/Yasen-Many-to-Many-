using Microsoft.EntityFrameworkCore;
using Yasen.Data;
using Yasen.Dtos;
using Yasen.Models;

namespace Yasen.Repos.BookRepos
{
    public class BookRepo : IBookRepo
    {
        private readonly DataContext _context;
        public BookRepo(DataContext context)
        {
            _context = context;
        }
        public void AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                PublishedDate = bookDto.PublishedDate,
                Title = bookDto.Title,
                Authors = _context.Authors.Where(x =>bookDto.AuthorId.Contains(x.Id)).ToList(),
                Genres = _context.Genres.Where(x =>bookDto.GenreId.Contains(x.Id)).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var b = _context.Books.FirstOrDefault(x=> x.Id == id);
            if (b != null)
            {
                _context.Books.Remove(b);
            }
            return;
        }

        public BookDto GetBook(int id)
        {
            var book = _context.Books.Include(x => x.Genres).Include(x => x.Authors).FirstOrDefault(x=> x.Id == id);
            var x = new BookDto
            {
                PublishedDate = book.PublishedDate,
                Title = book.Title,
                Authors = book.Authors.Select(x => x.Name).ToList(),
                Genres = book.Genres.Select(x => x.Name).ToList(),
            };
            return x;
        }

        public IEnumerable<BookDto> GetBooks()
        {
            var books = _context.Books.Include(x => x.Genres).Include(x => x.Authors).Select(
                x => new BookDto
                {
                    Title = x.Title,
                    PublishedDate= x.PublishedDate,
                    Authors = x.Authors.Select(v=> v.Name).ToList(),
                    Genres = x.Genres.Select(v=> v.Name).ToList(),
                }).ToList();
            return books;
        }

        public void UpdateBook(BookDto bookDto, int id)
        {
            var book = _context.Books.Include(x => x.Genres).Include(x => x.Authors).FirstOrDefault(x => x.Id == id);
             book = new Book
            {
                PublishedDate = bookDto.PublishedDate,
                Title = bookDto.Title,
                Authors = _context.Authors.Where(x => bookDto.AuthorId.Contains(x.Id)).ToList(),
                Genres = _context.Genres.Where(x => bookDto.GenreId.Contains(x.Id)).ToList(),
            };
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
