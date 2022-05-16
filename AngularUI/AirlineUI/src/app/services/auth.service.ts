import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { UserData } from '../models/UserData';
import { RegisterData } from '../models/RegisterData';

@Injectable()
export class AuthService {
    private _registerUrl = "https://localhost:44374/api/UserRegistation/InsertUserDetails";
    private _loginUrl = "https://localhost:44308/api/Users/authenticate"

    constructor(private http: HttpClient, private _router: Router) {

    }

    loginUser(user: any) {
        return this.http.post<any>(this._loginUrl, user)
    }

    registerUser(user: RegisterData) {
        console.log(user);
        return this.http.post<any>(this._registerUrl, user)
    }

    logoutUser() {
        localStorage.removeItem('token')
        this._router.navigate(['/events'])
    }

    getToken() {
        return localStorage.getItem('token')
    }
    loggedIn() {
        return !!localStorage.getItem('token')
    }
}