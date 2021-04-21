import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {ContactAddressService} from '../contact-address.service';

import { FormControl, FormGroup,Validator, Validators } from '@angular/forms';

@Component({
  selector: 'app-show-address',
  templateUrl: './show-address.component.html',
  styleUrls: ['./show-address.component.css']
})
export class ShowAddressComponent implements OnInit {
  id!:string;
  constructor(private activateRoute : ActivatedRoute,private contactService : ContactAddressService) {

   }
  addressList :any = [];
  contactAddForm : any;
  ngOnInit(): void {
    this.id = this.activateRoute.snapshot.paramMap.get('id') || "";
    this.fetchAddresses(this.id);

    this.contactAddForm = new FormGroup({
      FirstName:new FormControl(this.contactAddForm,Validators.required),
      LastName:new FormControl(null,Validators.required),
      PhoneNumber:new FormControl(null,[Validators.required,Validators.pattern('^[1-9][0-9]{8}')]),
    });
  }

  

  fetchAddresses(contactId:string){
       this.contactService.getAddressListForContact(contactId).subscribe(data=>{
         this.addressList = data;
       });     
  }

}
