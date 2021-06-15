using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class CreateMovieRequestModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Overview { get; set; }

        [Required]
        public string Tagline { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Budget { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Revenue { get; set; }

        [Url]
        public string ImdbUrl { get; set; }
        
        [Url]
        public string TmdbUrl { get; set; }
        
        [Required]
        [Url]
        public string PosterUrl { get; set; }

        [Required]
        [Url]
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        public List<GenreResponseModel> Genres { get; set; }
    }
}
