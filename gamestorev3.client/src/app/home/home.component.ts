import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  constructor(private accountService: AccountService) { }
  currentUser$: Observable<User | null>=of(null);

  ngOnInit() {
    this.currentUser$ = this.accountService.currentuser$;
  }
 

}
