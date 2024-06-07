import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit {
  model: any = {};
  loggedIn = false;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {

  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response),
          this.loggedIn = true
      },
      error: error => {
        console.log(error)
        console.log("You're here")
      }

    })
  }
  logout() {
    this.loggedIn = false;
  }


}
