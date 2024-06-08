import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'http://localhost:5097/api/';
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentuser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient, private toast: ToastrService) { }

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUserSource.next(user)
          this.toast.success('welcome' + user.Nickname)
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
}
