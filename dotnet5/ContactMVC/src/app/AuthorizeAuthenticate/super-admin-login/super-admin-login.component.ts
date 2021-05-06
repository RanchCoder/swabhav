import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SuperAdminLoginDTO } from 'src/app/DTO/SuperAdminLogin';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-super-admin-login',
  templateUrl: './super-admin-login.component.html',
  styleUrls: ['./super-admin-login.component.css']
})
export class SuperAdminLoginComponent implements OnInit {

  constructor(private _authService : AuthService,private _toastr : ToastrService,private _router : Router) { }
  loginForm :any;
  readonly Admin : string = 'Admin';
  readonly User : string = 'User';
  private readonly countIfUsernameIsTaken = 1;
  ngOnInit(): void {
     this.loginForm = new FormGroup({
      
       Email : new FormControl(null,[Validators.email,Validators.required]),
       Password : new FormControl(null,Validators.required),
      
     })
  }

  onSubmit(){
    let superAdminLoginData = new SuperAdminLoginDTO();
    superAdminLoginData.Email = this.loginForm.value.Email;
    superAdminLoginData.Password = this.loginForm.value.Password;
    this._authService.loginSuperAdmin(superAdminLoginData).subscribe(
      data=>{
        if(data != null){
         let token = (<any>data).token;
         localStorage.setItem("jwt",token);
           this._toastr.success("Welcome SuperAdmin");
           this._router.navigateByUrl(`/super-admin-dashboard`);
        }else{
          this._toastr.error("Cannot Login superadmin, please check credentials","ERROR");
        }
      },
      err=>{
        this._toastr.error("Something went wrong","ERROR");
      }
    );
  }
}
