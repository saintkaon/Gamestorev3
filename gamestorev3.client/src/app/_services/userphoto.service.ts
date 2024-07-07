import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { AccountService } from './account.service';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserphotoService {
  user = localStorage.getItem('user')

  currentUser: User =this.user ? JSON.parse(this.user) : null

  constructor(private http: HttpClient, private account: AccountService) { }
  baseUrl = environment.apiUrl
  uploadPhoto(file: File) {
   
   
    const emailAddress= this.currentUser.EmailAddress
   
   
    const formData: FormData = new FormData()
    formData.append('file', file, file.name)
    formData.append('emailAddress', emailAddress)
    return this.http.post(this.baseUrl, formData)
  
      
  }

  getImage(email: string) {
    email = this.currentUser.EmailAddress
    this.http.get(this.baseUrl, { params: { email } })

  }
    
  }



