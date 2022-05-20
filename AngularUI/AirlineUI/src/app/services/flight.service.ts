import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Injectable } from '@angular/core';
import {flightSearch} from '../models/InventoryData';

@Injectable()
export class flightService {
    private _eventUrl = "https://localhost:44321/api/AirlineInventory/search-inventories";
   
    constructor(private http: HttpClient) {
      
    }
    getFlightDetails(flight:any) {
        
        debugger;
        return this.http.post<any>(this._eventUrl, flight)
        
    } 
}