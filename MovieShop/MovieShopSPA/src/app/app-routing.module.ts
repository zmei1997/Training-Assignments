import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCastComponent } from './admin/create-cast/create-cast.component';
import { CreateMovieComponent } from './admin/create-movie/create-movie.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { MovieListComponent } from './movies/movie-list/movie-list.component';
import { FavoritesComponent } from './user/favorites/favorites.component';
import { ProfileComponent } from './user/profile/profile.component';
import { PurchasesComponent } from './user/purchases/purchases.component';
import { ReviewsComponent } from './user/reviews/reviews.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "admin/createmovie", component: CreateMovieComponent },
  { path: "admin/createcast", component: CreateCastComponent },
  { path: "genres/:id/movies", component: MovieListComponent },
  { path: "movies/:id", component:MovieDetailsComponent },
  { path: "purchases", component:PurchasesComponent },
  { path: "review", component:ReviewsComponent },
  { path: "favorites", component:FavoritesComponent },
  { path: "profile", component:ProfileComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
