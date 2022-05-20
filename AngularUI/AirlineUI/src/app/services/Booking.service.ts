import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Injectable } from '@angular/core';
import {BookflightsData} from '../models/BookingsData'

@Injectable()
export class BookingService {
    private _eventUrl = "https://localhost:44349/api/AirlineBooking/InsertBookindDetails";
   
    constructor(private http: HttpClient) {
      
    }
    PostBookingDetails(BookingDeatils:any) {
       
        debugger;
        console.log(BookingDeatils);
        return this.http.post<any>(this._eventUrl, BookingDeatils)
        
    } 
}