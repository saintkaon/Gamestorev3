import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  model: any = {}
  registerForm: FormGroup = new FormGroup({});
  constructor() { }

  

  ngOnInit()
  {
    this.intializeForm();
  }
  intializeForm() {
    this.registerForm = new FormGroup({
      email: new FormControl('', Validators.email),
      password: new FormControl('', [Validators.minLength(4), Validators.maxLength(12)]),
      confirmpassword: new FormControl('', [Validators.required, this.validatePassword('password')]),
      nickname: new FormControl
    })
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmpassword'].updateValueAndValidity()
    })
  }

  validatePassword(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {notMatching: true}
    }

  }

  register() { }



}
