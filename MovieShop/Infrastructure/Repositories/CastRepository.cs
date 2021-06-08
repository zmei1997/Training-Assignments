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
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext):base(dbContext)
        {
        }

        public override Cast GetById(int id)
        {
            var cast = _dbContext.Casts.Where(c => c.Id == id).Include(c => c.MovieCasts).ThenInclude(c => c.Movie).FirstOrDefault();
            return cast;
        }
    }
}
