import { Component, OnInit } from '@angular/core';
import {AddressService} from '../address.service';
import {ActivatedRoute,ParamMap, Router} from '@angular/router';
import {Address} from '../Address';
@Component({
  selector: 'app-view-address',
  templateUrl: './view-address.component.html',
  styleUrls: ['./view-address.component.css']
})
export class ViewAddressComponent implements OnInit {

  constructor(private _addressService : AddressService,private activateRoute : ActivatedRoute,private _router : Router) { }
  addressData = [];
  contactId : any;
  ngOnInit(): void {
     this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
       this.contactId = param.get('id');
     })
     
     this.fetchAddressForContact(this.contactId); 
  }

  fetchAddressForContact(contactId){
        this._addressService.getAddressList(contactId).subscribe(data=>{
          console.log(data);
          this.addressData = data;
        });
  }

  editAddress(address : Address){
    
       this._router.navigate(['/editAddress'],{state:{data:address}});
  }

  deleteAddress(address){

  }
}
