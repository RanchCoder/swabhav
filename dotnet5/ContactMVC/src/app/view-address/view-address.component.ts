import { Component, OnInit } from '@angular/core';
import {AddressService} from '../address.service';
import {ActivatedRoute,ParamMap, Router} from '@angular/router';
import {Address} from '../Address';
import { ContactAddressService } from '../contact-address.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-view-address',
  templateUrl: './view-address.component.html',
  styleUrls: ['./view-address.component.css']
})
export class ViewAddressComponent implements OnInit {

  userId: any;
  contactId: string;
  constructor(private _router : Router,
    private activateRoute : ActivatedRoute,
    private addressService : AddressService,
    private toastr : ToastrService) {

   }
  addressData :any = [];
  contactAddForm : any;
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
      this.userId = param.get('userId');
      this.contactId = param.get('contactId');
      console.log(this.userId);
      
    })
   
     this.fetchAddressForContact(this.userId,this.contactId); 
  }

  fetchAddressForContact(userId,contactId){
        this.addressService.getAddressList(userId,contactId).subscribe(data=>{
          if(data.length > 0){
            console.log(data);
            this.addressData = data;
            this.toastr.info("fetched contact's address",'Success');  
          }else{
            this.toastr.warning("unable to fetch contact's address");
          }
        },
        err=>{
          this.toastr.error("something went wrong","Error");
        }
        );
  }

  editAddress(address : Address){
    
       this._router.navigate(['/editAddress'],{state:{data:address}});
  }

  deleteAddress(userId,contactId,addressId){
    this.addressService.deleteAddress(userId,contactId,addressId).subscribe(data=>{
                  if(data != null){
                    this.toastr.info("address deleted successfully","Deleted");
                    this._router.navigate(['/showContacts',userId]);
                  }else{
                    
                      this.toastr.warning("cannot delete address");
                    
                  }
    },
    err=>{
      this.toastr.error("Something went wrong","Error");
    }
    );

  }
}
