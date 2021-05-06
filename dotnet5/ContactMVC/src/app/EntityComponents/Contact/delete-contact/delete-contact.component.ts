import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContactAddressService } from '../../../Services/contact-address.service';

@Component({
  selector: 'app-delete-contact',
  templateUrl: './delete-contact.component.html',
  styleUrls: ['./delete-contact.component.css']
})
export class DeleteContactComponent implements OnInit {

  constructor(private _contactService:ContactAddressService,private router : Router,private activateRoute : ActivatedRoute,private toastr:ToastrService) { }
  contactId : any;
  userId:any;
  responseData : any;
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
      console.log(param);
      this.userId = param.get('userId');
      this.contactId = param.get('contactId');
      console.log("userId " + this.userId + "   " + this.contactId);
    this.sendDeleteRequest(this.userId,this.contactId);
  })


}

sendDeleteRequest(userId:any,contactId:any){
  this._contactService.deleteContact(userId,contactId).subscribe(data=>{
       if(data != null){
         this.toastr.success("Deleted Successfully");
         this.router.navigate(['/showContacts',this.userId]);
       }else{
         this.toastr.warning("Cannot delete contact");
       }
        
  },
  err=>{
    this.toastr.error("Something went wrong","ERROR");
  }
  );
}


}