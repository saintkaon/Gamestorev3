import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { GamesListComponent } from './games/games-list/games-list.component';
import { AddgamesComponent } from './publisher/addgames/addgames.component';
import { BecomeapublisherComponent } from './publisher/becomeapublisher/becomeapublisher.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

const routes: Routes = [
  { path: '', redirectTo:'home'},
  { path: 'register', component: RegisterComponent },
  { path: 'browsegames', component: GamesListComponent },
  { path: 'addgames', component: AddgamesComponent },
  { path: 'publisher', component: BecomeapublisherComponent },
  { path: 'home', component: HomeComponent },
  { path: '**', component: NotFoundComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
