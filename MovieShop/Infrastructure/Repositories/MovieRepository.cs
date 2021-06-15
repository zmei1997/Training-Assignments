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
            //var allMovies = await _dbContext.Movies.ToListAsync();
            //foreach (var movie in allMovies)
            //{
            //    var rating = await _dbContext.Reviews.Where(r => r.MovieId == movie.Id).DefaultIfEmpty().AverageAsync(r => r == null ? 0 : r.Rating);
            //    movie.Rating = rating;
            //}
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Rating).Take(30).ToListAsync();

            return movies;
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

        public async Task<IEnumerable<Review>> GetReviewsByMovieId(int id)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).Include(r=>r.User).ToListAsync();
            return reviews;
        }

        public async Task<IEnumerable<Movie>> GetMovieByGenreId(int id)
        {
            var movies = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == id).SelectMany(g => g.Movies).ToListAsync();
            return movies;
        }
    }
}
