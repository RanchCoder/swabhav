import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ContactAddressService {
 
  

  constructor(private http : HttpClient) { 
    
  }
  readonly tenantId : any = localStorage.getItem('tenantId');
  readonly ApiUrl = `https://contact-api.azurewebsites.net/api/v1/tenants/${this.tenantId}/users`;
 
  getContactList(userId:any):Observable<any[]>{
    return this.http.get<any>(this.ApiUrl+`/${userId}/contacts`);
  }

  

  addContact(userId,contact:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(contact);
    return this.http.post(this.ApiUrl+`/${userId}/contacts`,body,{'headers':headers,responseType: 'text' as 'json'});
  }

  getContactById(userId:any,contactId:any):Observable<any>{
    return this.http.get<any>(this.ApiUrl+`/${userId}/contacts/${contactId}`);
  }

  getAddressListForContact(userId : any,contactId:any):Observable<any[]>{
    return this.http.get<any>(this.ApiUrl+`${userId}/contacts/${contactId}/addresses`);
  }

  editContact(userId : any,contact:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(contact);
    return this.http.put(this.ApiUrl+`/${userId}/contacts`,body,{'headers':headers,responseType: 'text' as 'json'});

  }

  deleteContact(userId : any,contactId:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(contactId);
    return this.http.delete(this.ApiUrl+`/${userId}/contacts/${contactId}`,{'headers':headers,responseType: 'text' as 'json'});
  }
  
  addContactToFavorite(userId:any,contactId:any):Observable<any>{
    let headers = {'content-type':'application-json'};
    return this.http.put(this.ApiUrl+`/${userId}/contacts/${contactId}/favoriteContact`,{'headers':headers});
  }

  //  getNumbersApiData(numberInfo:any):Observable<string>{
  //   const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');
  //   return this.http.get<any>(`http://numbersapi.com/${parseInt(numberInfo)}`,{ headers, responseType: 'text' as 'json'  });
  // }
}
