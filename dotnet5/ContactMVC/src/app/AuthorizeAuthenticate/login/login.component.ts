import { Component, OnInit } from '@angular/core';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../Services/auth.service';
import {JwtHelperService} from '@auth0/angular-jwt';
import { Login } from '../../DTO/Login';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService : AuthService,private _router : Router,private toastr : ToastrService,private jwtHelper : JwtHelperService) { }
  loginForm :any;
  readonly Admin : string = 'Admin';
  readonly User : string = 'User';
  private readonly countIfUsernameIsTaken = 1;
  ngOnInit(): void {
     this.loginForm = new FormGroup({
       CompanyName: new FormControl(null,Validators.required),
       Email : new FormControl(null,[Validators.email,Validators.required]),
       Password : new FormControl(null,Validators.required),
      
     })
  }

  get companyName(){
    return this.loginForm.get('CompanyName') as FormControl;
  }

  fetchTenantIdByCompanyName(inputText:any){
     
    console.log(inputText.target.value);
    if(inputText.target.value.length > 0){
      
      this.toastr.info("validating company name"); 
      this.authService.fetchTenantFromCompanyName(inputText.target.value)
    .subscribe(
      data=>{
        console.log(data);
        if(data.token != null){
          console.log('yes');
          localStorage.setItem('tenantId',data.token);
          localStorage.setItem('companyName',data.companyName);
          this.toastr.success("Company name is authentic");
      
        }else{
         this.companyName.setErrors({invalid:true});
         this.toastr.warning("Company name is not present in our records");
        }
      },
      err=>{
        this.companyName.setErrors({invalid:true});
        
        this.toastr.warning("Cannot verify company","ERROR");
      });
    }
         
  }

   onSubmit(){
     console.log(this.loginForm.value);
     var loginData = new Login();
     loginData.email = this.loginForm.value.Email;
     loginData.password = this.loginForm.value.Password;
     
     let tenantId = localStorage.getItem("tenantId");
     this.authService.loginUser(tenantId,loginData).subscribe(

       data=>{
        const token = (<any> data).token;
         console.log(token);
         localStorage.setItem("jwt",token);
         var tokenPayLoad = this.jwtHelper.decodeToken(token);
         
         var userRole = tokenPayLoad.role;
         if(userRole == 'Admin'){
                        window.location.replace('/dashboard');
          }
          else if(userRole == 'User'){
              console.log('yes user');
              this._router.navigateByUrl(`/showContacts/${tokenPayLoad.userId}`);
          }else{
                console.log('no body');
          }
         
         //  if(data != null){
          
        //    let userId = data.replace(/["]+/g,'');
          
        //     localStorage.setItem('userId',userId);
        //     this.authService.fetchUserNameRole(tenantId,userId).subscribe(
        //       data=>{
        //         if(data != null){
        //           console.log(data.userRole);
                  
        //           localStorage.setItem('role',data.userRole);
        //           localStorage.setItem('username',data.userName);
                  
        //           if(data.userRole == 'Admin'){
        //               window.location.replace('/dashboard');
        //           }else if(data.userRole == 'User'){
        //             console.log('yes user');
        //             this._router.navigateByUrl(`/showContacts/${userId}`);
        //           }else{
        //             console.log('no body');
        //           }
        //         }
        //       }
        //     );
            
           
        //  }
       },
       err=>{
        this.toastr.error("Cannot perform login try again");
       }
     );
   }
}
