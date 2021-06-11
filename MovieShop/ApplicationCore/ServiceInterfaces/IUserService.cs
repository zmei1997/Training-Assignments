﻿using ApplicationCore.Entities;
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
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);
        Task<UserLoginResponseModel> Login(string email, string password);

        // delete
        // EditUser
        // Change Password
        // Purchase Movie
        Task AddPurchasedMovie(UserPurchaseMovieRequestModel model);
        // Favorite Movie
        // Add Review
        // Get All Purchased Movies
        Task<List<MovieCardResponseModel>> GetAllPurchasedMovies(int userId);
        // Get All Favorited Movies
        // Edit Review
        // Remove Favorite
        // Get User Details
        // 
    }
}
