import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit {
  model: any = {};
  
  currentUser$: Observable<User | null> = of(null);

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentuser$

  }
 

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => 
        console.log(response)
        ,
      error: error => {
        console.log(error)
        console.log("You're here")
      }

    })
  }
  logout() {
   this.accountService.logout()
  }


}
