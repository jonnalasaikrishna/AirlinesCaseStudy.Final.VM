import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { userData } from '../models/BookingsData';
import { BookflightsData } from '../models/BookingsData';
import { BookingService } from '../services/Booking.service';
@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',

})
export class BookingComponent { 
  status:boolean=false;
   usersDateaModel:userData =new userData();
  // userDataModels:Array<userData>=new Array<userData>();
  userBookingDetailsArray: any=[];
  passengerArray: Array<userData> = [];
  response:string='';
  boarding:string='';
  
  bookflightDataModel: BookflightsData =new BookflightsData() ;

  constructor(public _BookingEvent: BookingService,private route: ActivatedRoute,private _router: Router) {
    debugger;
  }
  PostBookingDetails() {
    
    debugger;
    var flightDetails = {
      flightNumber: this.bookflightDataModel.flightNumber,
      dateOfJourney: this.bookflightDataModel.dateOfJourney,
      fromPlace: this.bookflightDataModel.fromPlace,
      toPlace: this.bookflightDataModel.toPlace,
      boardingTime: this.bookflightDataModel.boardingTime,
      emailID: this.bookflightDataModel.emailID,
      createdBy: this.bookflightDataModel.createdBy,
      seattype: 0,
      usersViewModels:this.passengerArray
    }
    console.log(flightDetails);
    this.userBookingDetailsArray.push(flightDetails);
    console.log(this.userBookingDetailsArray);
    this._BookingEvent.PostBookingDetails(this.userBookingDetailsArray).subscribe(res => this.SuccessGet(res), res => this.ErrorGet(res))

  }
  SuccessGet(res: any) {
    console.log(res);
    if(res.pnr !=null || res.pnr!='')
    {
    this.response="Ticket Booked Successfully Save PNR:"+res.pnr+"  For future use ";
    //Swal.fire(this.response);
    this._router.navigate(['/ticket'], { queryParams: { pnr:res.pnr} }); 
    }
    this.bookflightDataModel = new BookflightsData();
    debugger;

  }
  ErrorGet(res: any) {
    debugger;
    //Swal.fire('Something went Wrong try After Some time');
    console.log(res);
    
  }
  ngOnInit(): void {
   
    
  }
  
  AddPassenger() {
    debugger;
    var userDetails={
      userName:this.usersDateaModel.userName,
      passportNumber:this.usersDateaModel.passportNumber,
      age:Number(this.usersDateaModel.age)
    }

    this.passengerArray.push(userDetails);
    if(this.passengerArray.length>0)
    {
      this.status=true;
    }
    this.usersDateaModel = new userData();
  }
  EditCustomer(input: userData) {

    this.usersDateaModel = input;
  }

 

}