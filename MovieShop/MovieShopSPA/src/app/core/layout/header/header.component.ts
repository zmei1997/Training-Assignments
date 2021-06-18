import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isAuth!: boolean;
  user!: User;

  constructor(private authService: AuthenticationService) { }

  ngOnInit(): void {

    this.authService.isAuthenticated.subscribe(auth => {
      this.isAuth = auth;
      console.log('Auth Status:' + this.isAuth);
    });

    // subscribe current user infomation
    this.authService.currentUser.subscribe(
      user=> {this.user = user;}
    );
  }

  logout() {
    this.authService.logout();
  }
}