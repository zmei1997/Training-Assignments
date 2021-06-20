import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  isAuth!: boolean;
  user!: User;
  
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
  }

}
