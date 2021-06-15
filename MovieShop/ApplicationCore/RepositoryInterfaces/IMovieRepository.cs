using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository:IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetHighestRevenueMovies();
        Task<Movie> GetMovieDetailsById(int id);
        Task<IEnumerable<Review>> GetReviewsByMovieId(int id);
        Task<IEnumerable<Movie>> GetMovieByGenreId(int id);
    }
}
