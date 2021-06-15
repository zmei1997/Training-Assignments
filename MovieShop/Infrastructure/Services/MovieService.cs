using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
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
            // get the movie with genres and casts by id
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

        public async Task<MovieDetailsResponseModel> CreatMovie(CreateMovieRequestModel model)
        {
            var checkMovie = await _movieRepository.GetExistsAsync(m=>m.Title == model.Title);

            var genreList = new List<GenreResponseModel>();
            foreach (var genre in model.Genres)
            {
                genreList.Add(new GenreResponseModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            var movie = new Movie
            {
                Title = model.Title,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                RunTime = model.RunTime,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                Genres = (ICollection<Genre>)genreList
            };

            var newMovieModel = new MovieDetailsResponseModel
            {
                Title = model.Title,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                RunTime = model.RunTime,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                Genres = genreList
            };

            await _movieRepository.AddAsync(movie);

            return newMovieModel;
        }

        public async Task<MovieDetailsResponseModel> UpdateMovie(int id, CreateMovieRequestModel model)
        {
            var movieToBeUpdated = await _movieRepository.GetByIdAsync(id);

            var genreList = new List<GenreResponseModel>();
            foreach (var genre in model.Genres)
            {
                genreList.Add(new GenreResponseModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            movieToBeUpdated.Title = model.Title;
            movieToBeUpdated.PosterUrl = model.PosterUrl;
            movieToBeUpdated.BackdropUrl = model.BackdropUrl;
            movieToBeUpdated.Overview = model.Overview;
            movieToBeUpdated.Tagline = model.Tagline;
            movieToBeUpdated.Budget = model.Budget;
            movieToBeUpdated.Revenue = model.Revenue;
            movieToBeUpdated.ImdbUrl = model.ImdbUrl;
            movieToBeUpdated.TmdbUrl = model.TmdbUrl;
            movieToBeUpdated.RunTime = model.RunTime;
            movieToBeUpdated.Price = model.Price;
            movieToBeUpdated.ReleaseDate = model.ReleaseDate;
            movieToBeUpdated.Genres = (ICollection<Genre>)genreList;

            var movieModel = new MovieDetailsResponseModel
            {
                Title = model.Title,
                PosterUrl = model.PosterUrl,
                BackdropUrl = model.BackdropUrl,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                RunTime = model.RunTime,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                Genres = genreList
            };

            await _movieRepository.UpdateAsync(movieToBeUpdated);
            return movieModel;
        }

        public async Task<List<MovieCardResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.ListAllAsync();
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

        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetTopRatedMovies();
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

        public async Task<List<MovieReviewsResponseModel>> GetMovieReviewsByMovieId(int id)
        {
            var reviews = await _movieRepository.GetReviewsByMovieId(id);
            var reviewList = new List<MovieReviewsResponseModel>();
            foreach (var review in reviews)
            {
                reviewList.Add(new MovieReviewsResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    Name = review.User.FirstName,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                });
            }
            return reviewList;
        }

        public async Task<List<MovieCardResponseModel>> GetMoviesByGenreId(int id)
        {
            var movies = await _movieRepository.GetMovieByGenreId(id);
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
    }
}
