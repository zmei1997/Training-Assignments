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
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserId(int id)
        {
            var favorites = await _dbContext.Favorites.Where(f => f.UserId == id).Include(f=>f.Movie).ToListAsync();
            return favorites;
        }
    }
}
