using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IPurchaseRepository:IAsyncRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetPurchasesByUserId(int id);
    }
}
