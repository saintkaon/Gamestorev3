import { Component, Input } from '@angular/core';
import { Games } from '../../_models/games';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrl: './game-card.component.css'
})
export class GameCardComponent {
  @Input() game: Games | undefined;
  construct() {

  }

}
