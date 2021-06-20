import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
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

  constructor(private authenticationService: AuthenticationService) {
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
    this.authenticationService.getUserPurchasedMovies(this.user.nameid).subscribe(pm => { this.movies = pm });
  }

}
