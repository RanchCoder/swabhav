import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Address} from './DTO/Address';
@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http : HttpClient) {

   }

   readonly tenantId : any = localStorage.getItem('tenantId');
   readonly ApiUrl = `https://tenantcontactmgmtapi.azurewebsites.net/api/v1/tenants/${this.tenantId}/users`;

   getAddressList(userId,contactId):Observable<Address[]>{
    return this.http.get<any>(this.ApiUrl+`/${userId}/contacts/${contactId}/addresses`);
  }

  addAddress(userId:any,contactId:any,address:Address):Observable<any>{
    console.log(address);
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(address);
    console.log(body);
    return this.http.post(this.ApiUrl+`/${userId}/contacts/${contactId}/address`,body,{'headers':headers,responseType: 'text' as 'json'});
  }

  getAddressById(userId,contactId,addressId:any):Observable<any>{
    return this.http.get<any>(this.ApiUrl+`/${userId}/contacts/${contactId}/addresses/${addressId}`);
  }


  editAddress(userId,contactId,address:Address):Observable<any>{
    const headers ={'content-type':'application/json'};
    console.log(address);
    const body = JSON.stringify(address);
    return this.http.put(this.ApiUrl+`/${userId}/contacts/${contactId}/address`,body,{'headers':headers,responseType: 'text' as 'json'});

  }

  deleteAddress(userId:any,contactId:any,addressId:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(addressId);
    return this.http.delete(this.ApiUrl+`/${userId}/contacts/${contactId}/address/${addressId}`,{'headers':headers,responseType: 'text' as 'json'});
  }
 
  
}
