using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yasen.Dtos;
using Yasen.Repos.AuthorRepos;
using Yasen.Repos.GenreRepos;

namespace Yasen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepo _repo;
        public GenresController(IGenreRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var s = _repo.GetGenres();
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var s = _repo.GetGenre(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpPost]
        public IActionResult Post(GenreDto genreDto)
        {
            _repo.AddGenre(genreDto);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult Put(GenreDto genreDto, int id)
        {
            _repo.UpdateGenre(genreDto,id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.DeleteGenre(id);
            return Accepted();
        }
    }
}
