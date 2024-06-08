import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { GamesListComponent } from './games/games-list/games-list.component';
import { AddgamesComponent } from './publisher/addgames/addgames.component';
import { BecomeapublisherComponent } from './publisher/becomeapublisher/becomeapublisher.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'browsegames', component: GamesListComponent },
  { path: 'addgames', component: AddgamesComponent },
  { path: 'publisher', component: BecomeapublisherComponent },
  { path: '**', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
