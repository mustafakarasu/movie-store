using System;
using System.Linq;
using AutoMapper;
using MovieStore.WebApi.DbOperations;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Handle(){
            var genre = dbContext.Genres.SingleOrDefault(x=>x.Name == Model.Name);

            if(genre is not null)
            {
                throw new InvalidOperationException("Tür sistemde kayıtlı!");
            }

            genre = mapper.Map<Genre>(Model);
            dbContext.Genres.Add(genre);
            dbContext.SaveChanges();
        }
    }
}