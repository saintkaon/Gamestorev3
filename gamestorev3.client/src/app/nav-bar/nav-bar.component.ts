import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit {
  model: any = {};
  
  currentUser$: Observable<User | null> = of(null);

  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentuser$

  }
  success(test: string) {
    this.toastr.success('Welcome' + test)
  }
 

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => { }
       
        ,
      error: error => {
        this.toastr.error(error)
      }

    })
  }
  logout() {
   this.accountService.logout()
  }


}
