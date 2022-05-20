import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterData } from '../models/RegisterData';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent  {

  successMessage : string =""

  registerUserData: RegisterData = new RegisterData();
  constructor(private _auth: AuthService, private _router: Router) { }


  registerUser() {
    debugger;
    this._auth.registerUser(this.registerUserData).subscribe(res => this.successMessage = res);
      // localStorage.setItem('token', res.token)
      this._router.navigate(['/login'])   
      
  }
  ngOnInit(): void{
    
  }

}