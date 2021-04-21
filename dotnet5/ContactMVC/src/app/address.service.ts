import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Address} from '../app/Address';
@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http : HttpClient) {

   }

   readonly tenantId : any = '668502a4-3f00-4378-918d-f74c14347bf1';
   readonly userId : any = '6e4996f3-c498-47ef-8c8e-a380428b0966';
   readonly contactId : any = '13fdc2ad-7d14-4146-bfc9-34f493a9fcbf';
   readonly ApiUrl = `http://localhost:58500/api/v1/tenants/${this.tenantId}/users/${this.userId}/contacts`;

   getAddressList(contactId):Observable<Address[]>{
    return this.http.get<any>(this.ApiUrl+`/${contactId}/addresses`);
  }

  addAddress(address:Address):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(address);
    return this.http.post(this.ApiUrl+`/address`,body,{'headers':headers,responseType: 'text' as 'json'});
  }

  getAddressById(addressId:any):Observable<Address[]>{
    return this.http.get<any>(this.ApiUrl+`/addresses/${addressId}`);
  }


  editAddress(contactId,address:Address):Observable<any>{
    const headers ={'content-type':'application/json'};
    console.log(address);
    const body = JSON.stringify(address);
    return this.http.put(this.ApiUrl+`/${contactId}/address`,body,{'headers':headers,responseType: 'text' as 'json'});

  }

  deleteAddress(addressId:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(addressId);
    return this.http.delete(this.ApiUrl+`/address/${addressId}`,{'headers':headers,responseType: 'text' as 'json'});
  }
 
  
}
