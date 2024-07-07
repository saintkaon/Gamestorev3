import { Component } from '@angular/core';
import { UserphotoService } from '../../_services/userphoto.service';
import { User } from '../../_models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  selectedFile: File | null = null;
  imageUrl: string | null = null;
  user = localStorage.getItem('user')

  currentUser: User = this.user ? JSON.parse(this.user) : null
  constructor(private image: UserphotoService) {


  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  onUpload() {
    if (this.selectedFile) {
      this.image.uploadPhoto(this.selectedFile).subscribe(response => {
        console.log('Image uploaded successfully', response);
        this.loadImage(this.currentUser.EmailAddress);
      }, error => {
        console.error('Error uploading image', error);
      });
    }
  }

  loadImage(email: string) {
    this.image.getImage(email).subscribe(response => {
      this.imageUrl = 'data:image/jpeg;base64,' + response.data;
    }, error => {
      console.error('Error loading image', error);
    });
}
