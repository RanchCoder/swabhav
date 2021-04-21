import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { createModifiersFromModifierFlags } from 'typescript';
import { ContactAddressService } from '../contact-address.service';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {

  constructor(private _contactService : ContactAddressService,private activateRoute : ActivatedRoute) {

   }
  id : any;
  contactData : any = {};
  editForm:any;
  responseMessage :any;
  
  ngOnInit(): void {
    this.id = this.activateRoute.snapshot.paramMap.get('id') || "";
    this.fetchContactById(this.id);

    
  

  }
  
  
   fetchContactById(id:any){
     this._contactService.getContactById(id).subscribe(data=>{
           
      
          this.contactData = data;
          this.createForm(this.contactData);
          
          
     })
   }

   createForm(contactData:any){
    this.editForm = new FormGroup({
      Id:new FormControl({value : this.contactData.id, disabled: true}),
      FirstName:new FormControl(this.contactData.firstName,Validators.required),
      LastName:new FormControl(this.contactData.lastName,Validators.required),
      PhoneNumber:new FormControl(this.contactData.phoneNumber,Validators.required),
    });
   }
   onSubmit(){
     console.log(this.editForm.getRawValue());
     this._contactService.editContact(this.editForm.getRawValue()).subscribe(data=>{
      this.responseMessage = data;
    });

   }
}
