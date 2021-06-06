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
        List<MovieCardResponseModel> GetTopRevenueMovies();
        MovieDetailsResponseModel GetMovieDetailsById(int id);
    }
}
