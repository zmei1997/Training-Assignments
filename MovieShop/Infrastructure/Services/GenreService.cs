using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<List<GenreResponseModel>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllGenres();
            var genresList = new List<GenreResponseModel>();
            foreach(var genre in genres)
            {
                genresList.Add(new GenreResponseModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return genresList;
        }
    }
}
