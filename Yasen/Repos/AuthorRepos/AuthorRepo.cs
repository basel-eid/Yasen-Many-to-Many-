using Yasen.Data;
using Yasen.Dtos;
using Yasen.Models;

namespace Yasen.Repos.AuthorRepos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly DataContext _context;
        public AuthorRepo(DataContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorDto authorDto)
        {
            var a = new Author
            {
                Name = authorDto.Name,
                EmailAddress = authorDto.EmailAddress,
                Phone = authorDto.Phone,
            };
            _context.Authors.Add(a);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
           var author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            return;
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            var author = _context.Authors.Select(x => new AuthorDto
            {
                Name = x.Name,
                EmailAddress = x.EmailAddress,
                Phone = x.Phone,
            }).ToList();
            return author;
        }

        public AuthorDto GetById(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == id);
            return new AuthorDto
            {
                Name = author.Name,
                EmailAddress = author.EmailAddress,
                Phone = author.Phone,
            };
           
        }

        public void UpdateAuthor(AuthorDto authorDto, int id)
        {
            var x = new Author
            {
                Name = authorDto.Name,
                EmailAddress = authorDto.EmailAddress,
                Phone = authorDto.Phone,
            };
            _context.Authors.Update(x);
            _context.SaveChanges();
        }
    }
}
