import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {}
  registerForm: FormGroup;
  validationErrors: string[] | undefined;
  constructor(private fb: FormBuilder, private accountService: AccountService,private router: Router,private toastr:ToastrService) {
    this.registerForm = new FormGroup({});
  }

  

  ngOnInit()
  {
    this.intializeForm();
  }
  intializeForm() {
    this.registerForm = this.fb.group({
      email: ['', [Validators.email, Validators.required]],
      nickname: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(12)]],
      confirmpassword: ['', [Validators.required, this.validatePassword('password')]],

    });
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmpassword'].updateValueAndValidity()
    })
  }

  validatePassword(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {notMatching: true}
    }

  }

  register() {
    const values = { ...this.registerForm.value }
    this.accountService.register(values).subscribe({
      next: () => {
        this.router.navigateByUrl('/home')
       
},
      error: error=> {
        this.validationErrors = error
        
       
      }
    })
  }



}
