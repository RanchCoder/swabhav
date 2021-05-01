import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import { User } from '../DTO/User';
import { Contact } from '../DTO/Contact';
@Injectable({
  providedIn: 'root'
})
export class AdminUserService {
 

  constructor(private _http:HttpClient,private _router : Router) { }
  
  readonly ApiUrl = `http://localhost:58500/api/v1/tenants`;
 
  readonly tenantId : any = localStorage.getItem('tenantId');
  readonly userId : any = localStorage.getItem('userId');
  getUsers():Observable<any[]>{
    return this._http.get<any>(this.ApiUrl+`/${this.tenantId}/users`);
  }

  getUserDetailsById(userId: string):Observable<any> {
    return this._http.get<any>(this.ApiUrl+`/${this.tenantId}/users/${userId}`);
  }

  getUserContact(userId:any):Observable<Contact[]>{
    return this._http.get<any>(this.ApiUrl+`/${this.tenantId}/users/${userId}/contacts`);
  }

  AddUser(userData:User):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(userData);
    return this._http.post<any>(this.ApiUrl+`/${this.tenantId}/users/register`,body,{'headers':headers,responseType: 'text' as 'json'});
  
  }

  updateUser(userId,userData:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(userData);
    console.log(body);
    return this._http.put(this.ApiUrl+`/${this.tenantId}/users/${userId}`,body,{'headers':headers,responseType: 'text' as 'json'});
 }

  deleteUser(userId:any):Observable<any>{
    const headers ={'content-type':'application/json'};
    
    return this._http.delete(this.ApiUrl+`/${this.tenantId}/users/${userId}`,{'headers':headers,responseType: 'text' as 'json'});
  }

  getCountData():Observable<any>{
    return this._http.get<any>(this.ApiUrl+`/${this.tenantId}/countData`);
  }
}