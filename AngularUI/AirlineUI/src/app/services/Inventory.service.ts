import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Injectable } from '@angular/core';
import {FlightInventoryDetails} from '../models/InventoryData';

@Injectable()
export class InventoryService {
    private _eventUrl = "https://localhost:44321/api/AirlineInventory/InsertInventryDetails";
   
    constructor(private http: HttpClient) {
      
    }
    postInventoryDetails(inventorys:FlightInventoryDetails) {
        
        debugger;
        return this.http.post<any>(this._eventUrl, inventorys)
        
    } 
}