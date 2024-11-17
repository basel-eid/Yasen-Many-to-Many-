using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yasen.Dtos;
using Yasen.Repos.AuthorRepos;

namespace Yasen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;
        public AuthorsController(IAuthorRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var s = _repo.GetAll();
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var s = _repo.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpPost] 
        public IActionResult Post(AuthorDto authorDto)
        {
            _repo.AddAuthor(authorDto);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult Put(AuthorDto authorDto , int id)
        {
            _repo.UpdateAuthor(authorDto, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.DeleteAuthor(id);
            return Accepted();
        }
    }
}
