import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { GamesService } from '../_services/games.service';
import { Games } from '../_models/games';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  gamez:Games[]=[]
  constructor(private accountService: AccountService, private gameService: GamesService) { }
  currentUser$: Observable<User | null>=of(null);

  ngOnInit() {
    this.currentUser$ = this.accountService.currentuser$;
    this.gameService.getGames();  
  }

  getmembers() {
    this.gameService.getGames().subscribe(
      {next:games=>this.gamez=games})
  }
 

}
