using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.WebApi.Application.GenreOperations.Commands.CreateGenre;
using MovieStore.WebApi.Application.GenreOperations.Commands.DeleteGenre;
using MovieStore.WebApi.Application.GenreOperations.Commands.UpdateGenre;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenres;
using MovieStore.WebApi.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.WebApi.Application.MovieOperations.Commands.DeleteMovie;
using MovieStore.WebApi.Application.MovieOperations.Commands.UpdateMovie;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStore.WebApi.DbOperations;

namespace MovieStore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GenreController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            var query = new GetGenresQuery(dbContext, mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public ActionResult GetGenreDetail(int id)
        {
            var query = new GetGenreDetailQuery(dbContext, mapper);
            query.GenreId = id;
            var validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            var command = new CreateGenreCommand(dbContext,mapper);
            command.Model = newGenre;
            var validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            var command = new UpdateGenreCommand(dbContext);
            command.GenreId = id;
            command.Model = updateGenre;

            var validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            var command = new DeleteGenreCommand(dbContext);
            command.GenreId = id;
            var validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}