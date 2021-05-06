import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import {AddressService} from '../../../address.service';
@Component({
  selector: 'app-delete-address',
  templateUrl: './delete-address.component.html',
  styleUrls: ['./delete-address.component.css']
})
export class DeleteAddressComponent implements OnInit {

  constructor(private _addressService:AddressService,private activateRoute : ActivatedRoute) {}
  id : any;
  responseData : any;
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((params:Params)=>{
      this.id = params.get("id");
      this.sendDeleteRequest(this.id);
    })
  }

  sendDeleteRequest(id){
    
  }

}
