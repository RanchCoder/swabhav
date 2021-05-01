import { Component, OnInit } from '@angular/core';
import { FormsModule,FormControl, FormGroup } from '@angular/forms';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {JwtHelperService} from '@auth0/angular-jwt';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private _http : HttpClient,private jwtHelper : JwtHelperService) { }
  loginForm:any;
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      Username : new FormControl(),
      Password : new FormControl(),
    })
  }

  onSubmit(){
    let body = JSON.stringify(this.loginForm.value);
    this._http.post("https://localhost:44333/api/login/Login",body,{headers: new HttpHeaders({
      "Content-Type":"application/json"
    })
  }).subscribe(response=>{
    const token = (<any> response).token;
    console.log(token);
    console.log(this.jwtHelper.decodeToken(token));
    console.log(this.jwtHelper.getAuthScheme);
  })
  ;
  }

}
