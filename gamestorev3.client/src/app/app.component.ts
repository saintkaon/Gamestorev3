import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AccountService } from './_services/account.service';
import {User} from './_models/user'

interface Users {
  EmailAddress: string;
  Password: string;
  Nickname: string;
  
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  public users: Users[] = [];
  model: any = {};
  loggedIn=false;

  constructor(private http: HttpClient, private AccountService: AccountService) { }

  ngOnInit() {
    this.getUsers();
    this.setCurrentUser();

  }
  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.AccountService.SetCurrentUser(user);
   
  }

  getUsers() {
    this.http.get<Users[]>('/api/Users').subscribe({
      next: result => this.users = result,
      error: error => console.log(error),
      complete: () => console.log("Complete")

    })
   

    const title = 'gamestorev3.client';
  }


}
