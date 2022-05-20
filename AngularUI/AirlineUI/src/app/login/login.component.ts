import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserData } from '../models/UserData';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  //imageUrl='././assets/loginbg.jpg';

  loginUserData: UserData = new UserData();
  userId: string = "";
  constructor(private _auth: AuthService, private _router: Router) { }
  
  loginUser() {
    debugger;
    this._auth.loginUser(this.loginUserData).subscribe(res => {
      debugger;
      localStorage.setItem('roleId', res.roleId)
      localStorage.setItem('userId', res.userId)
      localStorage.setItem('token', res.token)
      if (localStorage.getItem('roleId') == "2")
        this._router.navigate(['/bookings'])
      else if (localStorage.getItem('roleId') == "1")
        this._router.navigate(['/inventorys'])
    },
      err => {
        debugger;
        console.log(err)})
      
  }
}