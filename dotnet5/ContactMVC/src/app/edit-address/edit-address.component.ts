import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Address } from '../Address';
import {AddressService} from '../address.service';
@Component({
  selector: 'app-edit-address',
  templateUrl: './edit-address.component.html',
  styleUrls: ['./edit-address.component.css']
})
export class EditAddressComponent implements OnInit {

  constructor(private _addressService : AddressService) { }
  
  
  
  addressData : Address;
  editForm : any;
  responseMessage:any;
  ngOnInit(): void {
    this.addressData = history.state.data;
    this.editForm = new FormGroup({
      Id:new FormControl({value : this.addressData.id, disabled: true}),
      City:new FormControl({value : this.addressData.city},[Validators.required]),
      State:new FormControl({value : this.addressData.state},Validators.required),
      Country:new FormControl({value : this.addressData.country},Validators.required),
      ContactId:new FormControl({value : this.addressData.contactID, disabled: true}),
      
    });
  }
   
  onSubmit(){
    console.log(this.editForm.getRawValue());
    this._addressService.editAddress(this.addressData.contactID,this.editForm.getRawValue()).subscribe(data=>{
      this.responseMessage = data;
  })
}
}
