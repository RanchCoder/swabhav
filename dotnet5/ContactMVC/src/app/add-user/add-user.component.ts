import { Component, OnInit, } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminUserService } from '../admin-user.service';
import {AuthService} from '../auth.service';
import { User } from '../User';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  countIfEmailIsTaken: any = 1;

  constructor(private _router:Router ,private _authService : AuthService,private _adminService : AdminUserService,private toastr : ToastrService) { }
  
  addUserForm : any;
  ngOnInit(): void {
    this.addUserForm = new FormGroup({
      Email:new FormControl(null,[Validators.email,Validators.required]),
      Username:new FormControl(null,[Validators.pattern("[a-zA-Z ]{8,25}"),Validators.required]),
      Password:new FormControl(null,Validators.required),
      UserRole:new FormControl(null,Validators.required)
    });
  }


  get email(){
    return this.addUserForm.get('Email') as FormControl;
  }

  get username(){
    return this.addUserForm.get('Username') as FormControl;
  }

  validateEmail(event:any){
    if(event.target.value != null){
      this._authService.validateEmail(event.target.value).subscribe(
        dataCount=>{
            if(dataCount >= this.countIfEmailIsTaken){
              this.email.setErrors({'notAvailable':true});
            }
        },
        err=>{
          this.email.setErrors({invalid:true});
        }
      );
    }
  }

  
  onSubmit(){
    var user = new User();
    user.username = this.addUserForm.value.Username;
    user.password = this.addUserForm.value.Password;
    user.email = this.addUserForm.value.Email;
    user.userRole = this.addUserForm.value.UserRole;
    console.log(user);
    
    this._adminService.AddUser(user).subscribe(data=>{
      
    this.toastr.success("User added");
    this._router.navigate(['/listUsers']);
    },
    err=>{
      this.toastr.error(err);
    }
    );
  }



}
