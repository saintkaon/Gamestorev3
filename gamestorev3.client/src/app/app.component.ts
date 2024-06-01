import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NavBarComponent } from './nav-bar/nav-bar.component';

interface Users {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  public users: Users[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getUsers();
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
