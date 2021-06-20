import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { UserService } from 'src/app/core/services/user.service';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {

  isAuth!: boolean;
  user!: User;
  movies!: MovieCard[];

  constructor(private authenticationService: AuthenticationService, private userService:UserService) {
    this.authenticationService.isAuthenticated.subscribe(auth => {
      this.isAuth = auth;
      console.log('Auth Status:' + this.isAuth);
      if (this.isAuth) {
        // subscribe current user infomation
        this.authenticationService.currentUser.subscribe(
          user => { this.user = user; }
        );
      }
    });

  }

  ngOnInit(): void {
    this.userService.getUserPurchasedMovies(this.user.nameid).subscribe(pm => { this.movies = pm });
  }

}
