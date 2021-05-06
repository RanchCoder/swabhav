import { Component, OnInit } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {ContactAddressService} from '../../../Services/contact-address.service';
import {AddressService} from '../../../address.service';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-show-contacts',
  templateUrl: './show-contacts.component.html',
  styleUrls: ['./show-contacts.component.css']
})
export class ShowContactsComponent implements OnInit {

  constructor(private contactService :ContactAddressService,private _addressService : AddressService,private _router : Router,private activateRoute : ActivatedRoute,private toastr : ToastrService) {

   }
  
  contactId!:string;
  contactList : any = [];
  userId :any;
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
      this.userId = param.get('userId');
      console.log(this.userId);
      this.fetchContactList(this.userId);
    })
    
  }
  
  fetchContactList(userId){
    this.contactService.getContactList(userId).subscribe(data=>{
      if(data.length > 0){
        this.contactList = data;
    
      }else{
        this.toastr.success("No contacts to show", "Add new contacts");
      }
    },
    err=>{
      this.toastr.error("Something went wrong");
    }
    );
  }

  fetchAddress(id:string){
    this.contactId = id;
  //  this._router.navigate(['/address/',this.contactId]);
  }

  addOrRemoveFavorite(userId:any,contactId:any){
    this.contactService.addContactToFavorite(userId,contactId).subscribe(
      data=>{
        if(data != null){          
      
        this._router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
         this._router.navigate(['showContacts/',userId]);
        })
        }
        else{
          this.toastr.warning("Cannot add contact to favorite");
        }
      },
      
    );
}

}
