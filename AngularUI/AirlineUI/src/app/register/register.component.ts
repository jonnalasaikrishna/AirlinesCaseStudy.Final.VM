import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterData } from '../models/RegisterData';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent  {

  registerUserData: RegisterData = new RegisterData();
  constructor(private _auth: AuthService, private _router: Router) { }
  registerUser() {
    this._auth.registerUser(this.registerUserData).subscribe(res => {
      localStorage.setItem('token', res.token)
      this._router.navigate(['/special'])
    },
      err => console.log(err));
  }

}