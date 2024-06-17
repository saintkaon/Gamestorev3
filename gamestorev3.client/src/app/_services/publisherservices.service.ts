import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../environments/environment.development';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PublisherservicesService {

  apiUrl = environment.apiUrl;
  constructor(private client: HttpClient, private toast: ToastrService) { }
 
    currentuserID = JSON.parse(localStorage.getItem('user')!);
  //becomeadeveloper(id: number) {
  //  this.client.post(this.apiUrl + 'publisher/register', id).pipe(
  //    map()
  //  )


  //}
}
