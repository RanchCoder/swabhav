import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContactAddressService } from '../contact-address.service';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {

  constructor(private _contactService : ContactAddressService,private router : Router,private activateRoute : ActivatedRoute,private toastr : ToastrService) {

   }
  contactId : any;
  userId:any;
  contactData : any = {};
  editForm:any;
  responseMessage :any;
  
  ngOnInit(): void {
  this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
         console.log(param);
         this.userId = param.get('userId');
         this.contactId = param.get('contactId');
         console.log("userId " + this.userId + "   " + this.contactId);
         this.fetchContactById(this.userId,this.contactId);
   }); 

  }
  
  
   fetchContactById(userId:any,contactId:any){
     this._contactService.getContactById(userId,contactId).subscribe(data=>{     
       if(data != null){
        console.log("data is fetched");
        this.contactData = data;
        this.createForm(this.contactData);   
       }  
       else{
         this.toastr.error("No such contact exists");
       }       
     },
     err=>{
       this.toastr.error("something went wrong");
     }
     )
   }

   createForm(contactData:any){
    this.editForm = new FormGroup({
      Id:new FormControl({value : contactData.id, disabled: true}),
      FirstName:new FormControl(contactData.firstName,Validators.required),
      LastName:new FormControl(contactData.lastName,Validators.required),
      PhoneNumber:new FormControl(contactData.phoneNumber,Validators.required),
    });
   }
   onSubmit(){
     console.log(this.editForm.getRawValue());
     console.log(typeof this.userId);
     this._contactService.editContact(this.userId,this.editForm.getRawValue()).subscribe(data=>{
      if(data != null){
        this.toastr.success("Contact updated successfully");
         this.router.navigate(['/showContacts',this.userId]);
      }else{
        this.toastr.warning("cannot update contact");
      }
    },
    err=>{
      this.toastr.error("something went wrong");
    }
    );

   }
}
