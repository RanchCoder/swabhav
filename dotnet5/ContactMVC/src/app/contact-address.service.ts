import { Injectable } from '@angular/core';
import {HttpClient, HttpClientModule, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ContactAddressService {
 
  

  constructor(private http : HttpClient) { 
    
  }
  readonly tenantId : any = '668502a4-3f00-4378-918d-f74c14347bf1';
  readonly userId : any = '6e4996f3-c498-47ef-8c8e-a380428b0966';
  readonly ApiUrl = `http://localhost:58500/api/v1/tenants/${this.tenantId}/users/${this.userId}/contacts`;
 
  getContactList():Observable<any[]>{
    return this.http.get<any>(this.ApiUrl);
  }

  addContact(contact:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(contact);
    return this.http.post(this.ApiUrl,body,{'headers':headers,responseType: 'text' as 'json'});
  }

  getContactById(contactId:any):Observable<any[]>{
    return this.http.get<any>(this.ApiUrl+`/${contactId}`);
  }

  getAddressListForContact(contactId:any):Observable<any[]>{
    return this.http.get<any>(this.ApiUrl+`/${contactId}/addresses`);
  }

  editContact(contact:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(contact);
    return this.http.put(this.ApiUrl,body,{'headers':headers,responseType: 'text' as 'json'});

  }

  deleteContact(contactId:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(contactId);
    return this.http.delete(this.ApiUrl+`/${contactId}`,{'headers':headers,responseType: 'text' as 'json'});
  }
  

  //  getNumbersApiData(numberInfo:any):Observable<string>{
  //   const headers = new HttpHeaders().set('Content-Type', 'text/plain; charset=utf-8');
  //   return this.http.get<any>(`http://numbersapi.com/${parseInt(numberInfo)}`,{ headers, responseType: 'text' as 'json'  });
  // }
}
