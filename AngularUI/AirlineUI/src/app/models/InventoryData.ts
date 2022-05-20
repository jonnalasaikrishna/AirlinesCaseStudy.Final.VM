import { NgForm,FormGroup,Validators,FormBuilder, FormControl } from "@angular/forms";

export class FlightInventoryDetails{    
        flightNumber:string ='';
        airlineId =0;
        fromPlace:string ='';
        toPlace:string ='';
        startDate:Date=new Date();
        endDate:Date=new Date();
        startTime:string ='';
        endTime:string ='';
        scheduledDays:number =0;
        fclassCount:number =0;
        fclassAvailableCount:number =0;
        nclassCount:number =0;
        nclassAvailableCount:number =0;
        fticketCost:number =0;
        nticketCost:number =0;
        mealService:number =0;

        // formInventoryGroup:FormGroup;


        // constructor() {
        //     var _builder=new FormBuilder();
        //     this.formInventoryGroup=_builder.group({});
           
         
        //     var validationcollection=[];
        //     validationcollection.push(Validators.required);
        //     validationcollection.push(Validators.pattern("^[1-9][0-9]*$"));
     
        //     //Control==>validation
        //     this.formInventoryGroup.addControl("flightNumberControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("airLineIdControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("fromPlaceControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("toPlaceControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("startDateControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("endDateControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("startTimeControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("endTimeControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("scheduledDaysControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("instrumentControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("fClassCountControl",new FormControl('',Validators.compose(validationcollection)));
        //     this.formInventoryGroup.addControl("nClassCountControl",new FormControl('',Validators.compose(validationcollection)));
        //     this.formInventoryGroup.addControl("fticketCostControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("nticketCostControl",new FormControl('',Validators.required));
        //     this.formInventoryGroup.addControl("mealControl",new FormControl('',Validators.compose(validationcollection)));
        //  }
     }

//Flight details

export class flightsData {    
        flightNumber:string =''; 
        fromPlace:string ='';
        toPlace:string ='';
        startDate:string ='';
        endDate:string ='';
        startTime:string ='';
        endTime:string ='';
        scheduledDays:number =0;
        fclassCount:number =0;
        fclassAvailableCount:number =0;
        nclassCount:number =0;
        nclassAvailableCount:number =0;
        fticketCost:number =0;
        nticketCost:number =0;               
}

//Search flight data



export class flightSearch{
    fromDate:Date=new Date();
    fromPlace:string='';
    toPlace:string='';

    // formCustomerGroup:FormGroup;//Create

    
    // constructor() {
    //    var _builder=new FormBuilder();
    //    this.formCustomerGroup=_builder.group({});
    //   this.fromDate
    //    this.formCustomerGroup.addControl("dateofJourneyControl",new FormControl('',Validators.required));
    //    this.formCustomerGroup.addControl("fromplaceControl",new FormControl('',Validators.required));
    //    this.formCustomerGroup.addControl("toplaceControl",new FormControl('',Validators.required));}

    
}