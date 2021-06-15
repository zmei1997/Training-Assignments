using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        // delete
        // EditUser
        // Change Password
        //// Purchase Movie 
        // Favorite Movie
        // Add Review
        //// Get All Purchased Movies
        // Get All Favorited Movies
        // Edit Review
        // Remove Favorite
        //// Get User Details
        Task AddPurchasedMovie(UserPurchaseMovieRequestModel model);
        Task<List<MovieCardResponseModel>> GetAllPurchasedMovies(int userId);
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);
        Task<UserLoginResponseModel> Login(string email, string password);
        Task<UserRegisterResponseModel> GetUserDetails(int id);
        Task<User> GetUser(string email);
        Task<IEnumerable<UserReviewsResponseModel>> GetReviewsByUserId(int id);
        Task AddReview(UserReviewRequestModel model);
        Task UpdateReview(UserReviewRequestModel model);
        Task DeleteReview(int userId, int movieId);
        Task<IEnumerable<MovieCardResponseModel>> GetFavoritesByUserId(int id);
        Task AddFavorite(UserFavoriteRequestModel model);
        Task RemoveFavorite(UserFavoriteRequestModel model);
        Task<bool> FavoriteExists(int id, int movieId);
    }
}
