import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  
  constructor(private http: HttpClient) { }

  getUserPurchasedMovies(id:number) : Observable<MovieCard[]> {
    // set authorization header
    var header = {
      headers: new HttpHeaders()
        .set('Authorization',  `Bearer ${localStorage.getItem('jwtToken')}`)
    }

    return this.http.get(`${environment.apiUrl}${'User/'}${id}${'/purchases'}`, header).pipe(
      map(response=>response as MovieCard[])
    );
  }
}
