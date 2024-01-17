using System;
using System.Linq;
using MovieStore.WebApi.DbOperations;

namespace MovieStore.WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IMovieStoreDbContext dbContext;
        public int GenreId { get; set; }
        public DeleteGenreCommand(IMovieStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
            {
                throw new InvalidOperationException("Tür bulunamadı!");
            }

            dbContext.Genres.Remove(genre);
            dbContext.SaveChanges();
        }
    }
}
