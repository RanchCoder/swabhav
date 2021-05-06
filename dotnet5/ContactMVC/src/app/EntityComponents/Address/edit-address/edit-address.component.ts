
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {AddressService} from '../../../address.service';
@Component({
  selector: 'app-edit-address',
  templateUrl: './edit-address.component.html',
  styleUrls: ['./edit-address.component.css']
})
export class EditAddressComponent implements OnInit {

  constructor(private _addressService : AddressService,private _route:Router,private activateRoute:ActivatedRoute,private toastr:ToastrService) { }
  
  
  
  addressData : any = {};
  editForm : any;
  responseMessage:any;
  userId:any;
  contactId:any;
  addressId:any;
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
      this.userId = param.get('userId');
      this.contactId = param.get('contactId');
      this.addressId = param.get('addressId');
      console.log(this.userId);
    
    })
    this.fetchAddressDataById(this.userId,this.contactId,this.addressId);
  }

  fetchAddressDataById(userId,contactId,addressId){
    this._addressService.getAddressById(userId,contactId,addressId).subscribe(
      data=>{
        if(data != null){
          this.addressData = data;
          console.log(this.addressData);
          this.createForm(this.addressData);
        }else{
          this.toastr.warning("unable to fetch address");
        }
      },
      err=>{
        this.toastr.error("Something went wrong","Error");
      }
    );
  }

  createForm(addressData : any){
   
    this.editForm = new FormGroup({
      Id:new FormControl({value : addressData.id, disabled: true}),
      City:new FormControl({value : addressData.city},[Validators.required]),
      State:new FormControl({value : addressData.state},Validators.required),
      Country:new FormControl({value : addressData.country},Validators.required),
      ContactId:new FormControl({value : addressData.contactID, disabled: true}),
      
    });
  }
  
   
  onSubmit(){
    console.log(this.editForm.getRawValue());
    this._addressService.editAddress(this.userId,this.addressData.contactID,this.editForm.getRawValue())
    .subscribe(
      data=>{
        if(data != null){
            this.toastr.success("address updated","success");
            this._route.navigate(['/address',this.userId,this.contactId]);
        }else{
          this.toastr.warning("cannot update address","Failure");
        }
  },
  err=>{
    this.toastr.error("something went wrong","Error");
  }
  )
}
}
