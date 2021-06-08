using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        // method for getting top 30 highest revenue movies..
        Task<List<MovieCardResponseModel>> GetTopRevenueMovies();
        Task<MovieDetailsResponseModel> GetMovieDetailsById(int id);
    }
}
