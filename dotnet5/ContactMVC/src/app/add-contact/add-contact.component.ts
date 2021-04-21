import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup,Validator, Validators } from '@angular/forms';
import { ContactAddressService } from '../contact-address.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {

  constructor(private _contactService : ContactAddressService) { }

  ngOnInit(): void {
    
  }
  
  responseMessage :any;
  contactAddForm = new FormGroup({
    FirstName:new FormControl(null,Validators.required),
    LastName:new FormControl(null,Validators.required),
    PhoneNumber:new FormControl(null,[Validators.required,Validators.pattern('^[1-9][0-9]{8}')]),
  });

  onSubmit(){
     this._contactService.addContact(this.contactAddForm.value).subscribe(data=>{
       this.responseMessage = data;
     });
     
  }

}
