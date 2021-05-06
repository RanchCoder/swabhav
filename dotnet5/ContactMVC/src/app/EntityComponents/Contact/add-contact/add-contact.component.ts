import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContactAddressService } from '../../../Services/contact-address.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {

  constructor(private _contactService : ContactAddressService,private router : Router,private activateRoute : ActivatedRoute,private toastr : ToastrService) { }
  userId  : any;
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
      this.userId = param.get('userId');
      console.log(this.userId);
    })
    
  }
  
  responseMessage :any;
  contactAddForm = new FormGroup({
    FirstName:new FormControl(null,Validators.required),
    LastName:new FormControl(null,Validators.required),
    PhoneNumber:new FormControl(null,[Validators.required,Validators.pattern('^[1-9][0-9]{8}')]),
  });

  onSubmit(){
     this._contactService.addContact(this.userId,this.contactAddForm.value).subscribe(data=>{
      if(data != null){
          this.toastr.success("Contact Added successfully");
          
          this.router.navigate(['/showContacts',this.userId]);
      } else{
        this.toastr.error("Cannot add contact, try again :(");
      }
     },
     err=>{
       this.toastr.error("Something went wrong");
     });
     
  }

}
