import { Component, OnInit } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {ContactAddressService} from '../contact-address.service';
import {AddressService} from '../address.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-show-contacts',
  templateUrl: './show-contacts.component.html',
  styleUrls: ['./show-contacts.component.css']
})
export class ShowContactsComponent implements OnInit {

  constructor(private contactService :ContactAddressService,private _addressService : AddressService,private _router : Router) {

   }
  
  tenantId:any = this.contactService.tenantId;
  userId : any = this.contactService.userId;
  contactId!:string;
  contactList : any = [];
  
  ngOnInit(): void {
    this.fetchContactList();
  }
  
  fetchContactList(){
    this.contactService.getContactList().subscribe(data=>{
      this.contactList = data;
    });
  }

  fetchAddress(id:string){
    this.contactId = id;
    this._router.navigate(['/address/',this.contactId]);
  }
}
