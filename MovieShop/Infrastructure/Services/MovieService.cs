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

        public List<MovieCardResponseModel> GetTopRevenueMovies()
        {
            var movies = _movieRepository.GetHighestRevenueMovies();

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

        public MovieDetailsResponseModel GetMovieDetailsById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel
            {
                Id = 1,
                Title = "Avengers: Infinity War",
                PosterUrl = "",
                Budget = 1200000,
                Overview = "Test String"
            };

            return movieDetails;
        }
    }
}
