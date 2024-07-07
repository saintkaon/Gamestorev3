import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../_models/user';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentuser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient, private toast: ToastrService) { }

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        var user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUserSource.next(user)
          this.toast.success('Welcome' +" "+ user.nickname)
        }
        
      }
      )
    )

  }
  SetCurrentUser(user: User) {
    this.currentUserSource.next(user);

  }
  logout() {
    localStorage.removeItem('user')
    this.currentUserSource.next(null)
  }
  register(model: any): Observable<any> {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
          map((response: User) => {
              var user = response;
              if (user) {
                  localStorage.setItem('user', JSON.stringify(user));
                  this.currentUserSource.next(user);
                  this.toast.success('Thank you for registering,' + " " + user.nickname + ".");
              }
          }
          ));

  }
}
