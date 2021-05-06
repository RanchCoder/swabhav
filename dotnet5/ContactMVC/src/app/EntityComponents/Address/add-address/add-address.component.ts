import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {AddressService} from '../../../address.service';
@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.css']
})
export class AddAddressComponent implements OnInit {

  constructor(private _addressService : AddressService,private router : Router,private toastr : ToastrService,private activateRoute : ActivatedRoute) {

   }
  contactId : any;
  userId :any;
  addressForm:any;
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
      this.userId = param.get('userId');
      this.contactId = param.get('contactId');
      console.log(this.userId);
    
    })

    this.addressForm = new FormGroup({
      City: new FormControl(null,Validators.required),
      State:new FormControl(null,Validators.required),
      Country:new FormControl(null,Validators.required)
  
    });
  }
  
   
  

  onSubmit(){
    console.log(this.addressForm.value);
    this._addressService.addAddress(this.userId,this.contactId,this.addressForm.value).subscribe(data=>{
      if(data != null){
        this.toastr.success("address added","Success");
        this.router.navigate(['/showContacts',this.userId]);
      }else{
        this.toastr.warning("cannot add address");
      }

    },
    err=>{
      this.toastr.error("something went wrong","error");
    }
    )
  }

}
