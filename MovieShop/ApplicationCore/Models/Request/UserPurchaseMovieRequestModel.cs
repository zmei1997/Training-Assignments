using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class UserPurchaseMovieRequestModel
    {
        public UserPurchaseMovieRequestModel()
        {
            PurchaseDateTime = DateTime.Now;
            PurchaseNumber = Guid.NewGuid();
        }

        public int UserId { get; set; }
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public int MovieId { get; set; }
    }
}
