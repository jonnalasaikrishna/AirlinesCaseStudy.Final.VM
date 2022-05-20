import { Component, OnInit } from '@angular/core';
import { Router, Routes } from '@angular/router';
import {flightSearch} from '../models/InventoryData';
import{flightsData} from '../models/InventoryData';
import { flightService } from '../services/flight.service';
@Component({
  selector: 'app-searchflight',
  templateUrl: './searchflight.component.html'
})
export class SearchflightComponent implements OnInit {
  flights:Array<flightsData> = new Array<flightsData>();
  flightsmodel: flightsData=new flightsData();
  flightmodel:flightSearch=new flightSearch;
  
  constructor( public _fligentevn:flightService, private _router: Router) { 
    
  }

  GetFromServer(){
  var flightdto={
    fromDate:this.flightmodel.fromDate,
    fromPlace:this.flightmodel.fromPlace,
    toPlace:this.flightmodel.toPlace,
  }
   debugger;
    this._fligentevn.getFlightDetails(flightdto).subscribe(res=>this.SuccessGet(res),res=>this.ErrorGet(res))
  }
  SuccessGet(res:any){
    console.log(res);
    this.flights=res;
    
   
  }
  ErrorGet(res:any){ 
     debugger;  
    console.log(res);
  }
  ngOnInit(): void {
    
  }
 
Bookflight(input: flightsData) {
  debugger;
  console.log(flightsData)
  this._router.navigate(['/book'], { queryParams: { DateofJourny:input.startDate,FromPlace:input.fromPlace,Toplace:input.toPlace,BoardingTime:input.startTime} }); 
} 
}