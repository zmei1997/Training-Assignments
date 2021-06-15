using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ApplicationCore.Exceptions;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IReviewRepository _reviewRepository;
        private readonly IFavoriteRepository _favoriteRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, 
            IMovieRepository movieRepository, ICurrentUserService currentUserService, 
            IReviewRepository reviewRepository, IFavoriteRepository favoriteRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _movieRepository = movieRepository;
            _currentUserService = currentUserService;
            _reviewRepository = reviewRepository;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // first we need to check the email does not exists in our database

            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);

            if (dbUser != null)
                // email exists in db
                throw new ConflictException("User already exists, please try to login");

            // generate a unique Salt
            var salt = CreateSalt();

            // hash the password with userRegisterRequestModel.Password + salt from above step
            var hashedPassword = CreateHashedPassword(userRegisterRequestModel.Password, salt);

            // call the user repository to save the user Info

            var user = new User
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email,
                DateOfBirth = userRegisterRequestModel.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var createdUser = await _userRepository.AddAsync(user);

            // convert the returned user entity to UserRegisterResponseModel

            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };

            return response;
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            // go to database and get the user info -- row by email
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                // return null
                return null;
            }

            // get the password from UI and salt from above step from database and call CreateHashedPassword method

            var hashedPassword = CreateHashedPassword(password, user.Salt);

            if (hashedPassword == user.HashedPassword)
            {
                // user entered correct password

                var loginResponseModel = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return loginResponseModel;
            }

            return null;
        }

        private string CreateSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, Convert.FromBase64String(salt), KeyDerivationPrf.HMACSHA512, 10000, 256 / 8));
            return hashed;
        }

        public async Task<List<MovieCardResponseModel>> GetAllPurchasedMovies(int userId)
        {
            var purchases = await _purchaseRepository.GetPurchasesByUserId(userId);

            var puchasedMovieCardList = new List<MovieCardResponseModel>();
            foreach (var purchase in purchases)
            {
                puchasedMovieCardList.Add(new MovieCardResponseModel
                {
                    Id = purchase.Movie.Id,
                    PosterUrl = purchase.Movie.PosterUrl,
                    ReleaseDate = purchase.Movie.ReleaseDate.GetValueOrDefault(),
                    Title = purchase.Movie.Title
                });
            }
            return puchasedMovieCardList;
        }

        public async Task AddPurchasedMovie(UserPurchaseMovieRequestModel model)
        {
            var userId = _currentUserService.UserId;
            var movieDetail = await _movieRepository.GetByIdAsync(model.MovieId);
            var purchase = new Purchase
            {
                UserId = userId,
                PurchaseNumber = model.PurchaseNumber,
                TotalPrice = movieDetail.Price.Value,
                PurchaseDateTime = model.PurchaseDateTime,
                MovieId = model.MovieId
            };

            if (await _purchaseRepository.GetExistsAsync(p =>p.UserId == purchase.UserId && p.MovieId == purchase.MovieId))
            {
                throw new ConflictException("Movie already Purchased");
            }

            await _purchaseRepository.AddAsync(purchase);
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User");
            }
            var userRegisterModel = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return userRegisterModel;
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<IEnumerable<UserReviewsResponseModel>> GetReviewsByUserId(int id)
        {
            var userReviews = await _reviewRepository.GetReviewsByUserId(id);
            var userReviewList = new List<UserReviewsResponseModel>();
            foreach (var review in userReviews)
            {
                userReviewList.Add(new UserReviewsResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating,
                    CreatedDate = review.CreatedDate
                });
            }
            return userReviewList;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetFavoritesByUserId(int id)
        {
            var favorites = await _favoriteRepository.GetFavoritesByUserId(id);
            var favoriteMovieCardList = new List<MovieCardResponseModel>();
            foreach (var favorite in favorites)
            {
                favoriteMovieCardList.Add(new MovieCardResponseModel
                {
                    Id = favorite.Movie.Id,
                    PosterUrl = favorite.Movie.PosterUrl,
                    ReleaseDate = favorite.Movie.ReleaseDate.GetValueOrDefault(),
                    Title = favorite.Movie.Title
                });
            }
            return favoriteMovieCardList;

        }

        public async Task AddFavorite(UserFavoriteRequestModel model)
        {
            var favorite = new Favorite
            {
                UserId = model.UserId,
                MovieId = model.MovieId
            };

            await _favoriteRepository.AddAsync(favorite);
        }

        public async Task RemoveFavorite(UserFavoriteRequestModel model)
        {
            var favorite = new Favorite
            {
                UserId = model.UserId,
                MovieId = model.MovieId
            };

            await _favoriteRepository.DeleteAsync(favorite);
        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            return await _favoriteRepository.GetExistsAsync(f => f.MovieId == movieId && f.UserId == id);
        }

        public async Task AddReview(UserReviewRequestModel model)
        {
            var review = new Review
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                Rating = model.Rating,
                ReviewText = model.ReviewText,
                CreatedDate = DateTime.Now
            };

            await _reviewRepository.AddAsync(review);
        }

        public async Task UpdateReview(UserReviewRequestModel model)
        {
            var review = new Review
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                Rating = model.Rating,
                ReviewText = model.ReviewText,
                CreatedDate = DateTime.Now
            };

            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteReview(int userId, int movieId)
        {
            var review = await _reviewRepository.ListAsync(r => r.UserId == userId && r.MovieId == movieId);
            await _reviewRepository.DeleteAsync(review.First());
        }
    }
}
