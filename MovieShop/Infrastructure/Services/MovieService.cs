using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighestRevenueMovies();

            var movieCardList = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCardList.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                    Title = movie.Title
                });
            }

            return movieCardList;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailsById(int id)
        {
            // get the movie by id
            var movie = await _movieRepository.GetMovieDetailsById(id);

            var genreList = new List<GenreResponseModel>();
            foreach (var genre in movie.Genres)
            {
                genreList.Add(new GenreResponseModel
                { 
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            var castList = new List<CastResponseModel>();
            foreach (var movieCast in movie.MovieCasts)
            {
                castList.Add(new CastResponseModel
                { 
                    Id = movieCast.Cast.Id,
                    Name = movieCast.Cast.Name,
                    Gender = movieCast.Cast.Gender,
                    TmdbUrl = movieCast.Cast.TmdbUrl,
                    ProfilePath = movieCast.Cast.ProfilePath,
                    Character = movieCast.Character
                });
            }

            var movieDetails = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                RunTime = movie.RunTime,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Genres = genreList,
                Casts = castList
            };

            return movieDetails;
        }
    }
}
