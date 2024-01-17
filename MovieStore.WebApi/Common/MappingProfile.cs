using System.Linq;
using AutoMapper;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetail;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActors;
using MovieStore.WebApi.Application.CustomerOperations.Queries.GetCustomers;
using MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirector;
using MovieStore.WebApi.Application.GenreOperations.Commands.CreateGenre;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenres;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovies;
using MovieStore.WebApi.Application.OrderOperations.Queries.GetOrders;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Customer, CustomersViewModel>();
            CreateMap<Movie, ActorViewModel.MovieActorsViewModel>().ReverseMap();

            CreateMap<Actor, ActorViewModel>()
                .ForMember(dest => dest.movieActorsViewModel, opt => opt.MapFrom(src => src.MovieActors.Select(x => x.Movie).ToList()));

            CreateMap<Movie, ActorDetailViewModel.MovieActorsViewModel>().ReverseMap();

            CreateMap<Actor, ActorDetailViewModel>()
                .ForMember(dest => dest.movieActorsViewModel, opt => opt.MapFrom(src => src.MovieActors.Select(x => x.Movie).ToList()));

            CreateMap<Movie, DirectorViewModel.DirectorMovieViewModel>().ReverseMap();
            CreateMap<Director, DirectorViewModel>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.ToList()));

            CreateMap<Movie, DirectorDetailViewModel.DirectorMovieViewModel>().ReverseMap();
            CreateMap<Director, DirectorDetailViewModel>()
                .ForMember(dest => dest.directorMovieViewModel, opt => opt.MapFrom(src => src.Movies.ToList()));

            CreateMap<Actor, MovieViewModel.MovieActorsViewModel>().ReverseMap();

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => string.Concat(src.Director.Name, " ", src.Director.Surname)))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.movieActorsViewModel, opt => opt.MapFrom(src => src.MovieActors.Select(x => x.Actor).ToList()));

            CreateMap<Actor, MovieDetailViewModel.MovieActorsViewModel>().ReverseMap();
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => string.Concat(src.Director.Name, " ", src.Director.Surname)))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.movieActorsViewModel, opt => opt.MapFrom(src => src.MovieActors.Select(x => x.Actor).ToList()));

            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Movie.Id));

            CreateMap<CreateGenreModel, Genre>();

            CreateMap<Genre, GenreDetailViewModel>();

        }
    }
}