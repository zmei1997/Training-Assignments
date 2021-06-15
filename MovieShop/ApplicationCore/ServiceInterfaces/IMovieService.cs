using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        // method for getting top 30 highest revenue movies..
        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();
        Task<MovieDetailsResponseModel> GetMovieDetailsById(int id);
        Task<MovieDetailsResponseModel> CreatMovie(CreateMovieRequestModel model);
        Task<MovieDetailsResponseModel> UpdateMovie(int id, CreateMovieRequestModel model);
        Task<List<MovieCardResponseModel>> GetAllMovies();
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<MovieReviewsResponseModel>> GetMovieReviewsByMovieId(int id);
        Task<List<MovieCardResponseModel>> GetMoviesByGenreId(int id);
    }
}
