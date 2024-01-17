using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.WebApi.DbOperations;

namespace MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly IMovieStoreDbContext dbContext;
        private readonly IMapper mapper;

        public int GenreId { get; set; }

        public GetGenreDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = dbContext.Genres
                .Include(x => x.Customer)
                .SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Tür bulunamadı!");

            return mapper.Map<GenreDetailViewModel>(genre);
        }
    }
}