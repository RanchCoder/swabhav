import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { Login } from '../DTO/Login';
import { Registration } from '../DTO/Registration';
import { Tenant } from '../DTO/Tenant';
import { UserToken } from '../DTO/UserToken';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient,private _router : Router,private jwtHelper : JwtHelperService) { }

  readonly ApiUrl = `http://localhost:58500/api/v1/tenants`;

  validateCompanyName(companyName:any):Observable<any>{
    return this.http.get<any>(this.ApiUrl+`/companyIsUnique/${companyName}`);
  }
  
  validateEmail(email:any):Observable<any>{
    return this.http.get<any>(this.ApiUrl+`/companyEmailIsUnique/${email}`);
  }

  fetchTenantFromCompanyName(companyName:any):Observable<UserToken>{
    return this.http.get<any>(this.ApiUrl+`/companyTenantIsUnique/${companyName}`);
  }
  
  registerUser(registerUser : Registration):Observable<any>{
    
    const headers ={'content-type':'application/json'};
    const body = JSON.stringify(registerUser);
    return this.http.post(this.ApiUrl+`/user/registration`,body,{'headers':headers,responseType: 'text' as 'json'});
  }

  loginUser(tenantId:any,loginUser : Login){
    const headers ={'content-type':'application/json'};
    
    const body = JSON.stringify(loginUser);
    
    return this.http.post<any>(this.ApiUrl+`/${tenantId}/user/login`,body,{headers: new HttpHeaders({
      "Content-Type":"application/json"
    })});
  }

   
  getUserId(loginData:Login):Observable<UserToken>{
    return this.http.get<any>(this.ApiUrl+`/${localStorage.getItem('tenantId')}/userIsUnique/userId`);
  }

  fetchUserNameRole(tenantId,userId):Observable<any>{
    return this.http.get<any>(this.ApiUrl+`/${tenantId}/userNameAndRole/${userId}`);
  }

  loggedIn(){
    
   let token = localStorage.getItem("jwt");
   
   if(token != null)
    {
      let tokenPayLoad = this.jwtHelper.decodeToken(token);
         
      
      return true;
    }else{
      
      return false;
    }
  }

  getUserRoleFromToken(){
    let token = localStorage.getItem("jwt");
    let tokenPayLoad = this.jwtHelper.decodeToken(token);
    return tokenPayLoad.role;        
   
  }

  getTenantIdFromToken(){
    let token = localStorage.getItem("jwt");
    let tokenPayLoad = this.jwtHelper.decodeToken(token);
    return tokenPayLoad.tenantId;        
   
  }

  getUserIdFromToken(){
    let token = localStorage.getItem("jwt");
    let tokenPayLoad = this.jwtHelper.decodeToken(token);
    return tokenPayLoad.userId;        
   
  }

  getUserNameFromToken(){
    let token = localStorage.getItem("jwt");
    let tokenPayLoad = this.jwtHelper.decodeToken(token);
    return tokenPayLoad.username;        
   
  }

  getTenantNameFromToken(){
    let token = localStorage.getItem("jwt");
    let tokenPayLoad = this.jwtHelper.decodeToken(token);
    return tokenPayLoad.tenantName;
  }

  isLoggedOut(){
    localStorage.clear();
    this._router.navigate(['/login']);
  }

}
