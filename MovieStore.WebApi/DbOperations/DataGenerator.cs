using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using ( var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()) )
            {

                if ( !context.Genres.Any() )
                {
                    context.Genres.Add(new Genre() { Id = 1, Name = "Bilim-Kurgu", IsActive = true });
                    context.Genres.Add(new Genre() { Id = 2, Name = "Aksiyon", IsActive = true });
                    context.Genres.Add(new Genre() { Id = 3, Name = "Komedi", IsActive = true });
                }

                if ( !context.Customers.Any() )
                {
                    context.Customers.Add(new() { Id = 1, Name = "Ahmet", Surname = "SoyadAhmet", FavoriteGenreId = 1, PurchasedMoviesId = 1 });
                    context.Customers.Add(new() { Id = 2, Name = "Mehmet", Surname = "SoyadMehmet", FavoriteGenreId = 2, PurchasedMoviesId = 1 });
                }

                if ( !context.Actors.Any() )
                {
                    context.Actors.Add(new() { Id = 1, Name = "Kemal", Surname = "Sunal" });
                    context.Actors.Add(new() { Id = 2, Name = "Türkan", Surname = "Şoray" });
                    context.Actors.Add(new() { Id = 3, Name = "Cem", Surname = "Yılmaz" });
                    context.Actors.Add(new() { Id = 4, Name = "Yılmaz", Surname = "Erdoğan" });
                    context.Actors.Add(new() { Id = 5, Name = "Şebnem", Surname = "Bozoklu" });
                }

                if ( !context.Directors.Any() )
                {
                    context.Directors.Add(new() { Id = 1, Name = "Çağan", Surname = "Irmak" });
                    context.Directors.Add(new() { Id = 2, Name = "Atıf", Surname = "Yılmaz" });
                }

                if ( !context.Movies.Any() )
                {
                    context.Movies.Add(new()
                    {
                        Id = 1,
                        Name = "Hababam Sınıfı",
                        GenreId = 3,
                        DirectorId = 2,
                        Price = 10,
                        Year = new DateTime(1982, 01, 01),
                    });
                    context.Movies.Add(new()
                    {
                        Id = 2,
                        Name = "Sına",
                        GenreId = 2,
                        DirectorId = 1,
                        Price = 20,
                        Year = new DateTime(2015, 01, 01),
                    });
                }

                if (!context.MovieActors.Any())
                {
                    context.MovieActors.AddRange(new List<MovieActors>()
                    {
                        new() { ActorId = 1, MovieId = 1 },
                        new() { ActorId = 1, MovieId = 2 },
                        new() { ActorId = 2, MovieId = 2 },
                        new() { ActorId = 2, MovieId = 1 },
                        new() { ActorId = 3, MovieId = 1 },
                        new() { ActorId = 4, MovieId = 1 },
                        new() { ActorId = 4, MovieId = 2 },
                        new() { ActorId = 5, MovieId = 2 }
                    });
                }

                context.SaveChanges();
            }
        }
    }
}