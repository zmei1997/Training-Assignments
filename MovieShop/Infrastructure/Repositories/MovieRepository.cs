using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieDetailsById(int id)
        {
            var movie = await _dbContext.Movies.Where(m => m.Id == id).Include(mc => mc.MovieCasts).ThenInclude(c => c.Cast).Include(g => g.Genres).FirstOrDefaultAsync();
            var rating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty().AverageAsync(r => r == null ? 0 : r.Rating);
            movie.Rating = rating;
            return movie;
        }
    }
}
