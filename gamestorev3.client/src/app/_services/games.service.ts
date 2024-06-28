import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Games } from '../_models/games';


@Injectable({
  providedIn: 'root'
})
export class GamesService {
  BaseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getGames() {
   return this.http.get<Games[]>(this.BaseUrl+'games')
  }

}
