import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { UserData } from '../models/UserData';
import { RegisterData } from '../models/RegisterData';

@Injectable()
export class AuthService {
    private _registerUrl = "https://localhost:44380/api/UserRegistation/InsertUserDetails";
    private _loginUrl = "https://localhost:44372/api/Users/authenticate"

    constructor(private http: HttpClient, private _router: Router) {

    }

    loginUser(user: any) {
        return this.http.post<any>(this._loginUrl, user)
    }

    registerUser(user: RegisterData) {
        debugger;
        console.log(user);
        return this.http.post<any>(this._registerUrl, user)
    }

    logoutUser() {
        localStorage.removeItem('token')
        localStorage.removeItem('roleId')
        localStorage.removeItem('userId')
        this._router.navigate(['/search'])
    }

    getToken() {
        return localStorage.getItem('token')
    }
    loggedIn() {
        return !!localStorage.getItem('token')
    }

    adminLoggedIn() {
        if (!!localStorage.getItem('token') && localStorage.getItem('roleId') == "1")
            return true;
        else
            return false;
    }

    userLoggedIn() {
        if (!!localStorage.getItem('token') && localStorage.getItem('roleId') == "2")
            return true;
        else
            return false;
    }
}