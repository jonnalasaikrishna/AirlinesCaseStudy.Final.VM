import { Component, OnInit } from '@angular/core';
import { FlightInventoryDetails } from '../models/InventoryData';
import { InventoryService } from '../services/Inventory.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-inventorys',
  templateUrl: './inventorys.component.html'
})
export class InventorysComponent {
  successMessage : string =""
  
  InventoryModel: FlightInventoryDetails = new FlightInventoryDetails();
  
  constructor(public _InventoryEvent: InventoryService) { }

  PostInventoryDetails() {

    debugger;
    this._InventoryEvent.postInventoryDetails(this.InventoryModel).subscribe(res=>this.successMessage= res);

  }
  


  
  ngOnInit(): void {   
    
  }
}