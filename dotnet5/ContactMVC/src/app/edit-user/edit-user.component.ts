import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminUserService } from '../admin-user.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  userId: string;
  userData : any = {};
  editUserForm:any;
  countIfEmailIsTaken: 1;
  constructor(
    private _adminUserService : AdminUserService,
    private _authService:AuthService,
    private activateRoute:ActivatedRoute,
    private _router : Router,
    private toastr : ToastrService) { }
  
  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe((param:ParamMap)=>{
      
      this.userId = param.get('userId');
      
      this.fetchUserById(this.userId);
  });
  
}
  fetchUserById(userId: string) {
    this._adminUserService.getUserDetailsById(userId).subscribe(
      data=>{
        if(data != null){
          this.userData = data;
          this.createForm(this.userData);
        }else{
          this.toastr.error("Cannot fetch user data, Try Again");
        }
      },
      err=>{
        this.toastr.warning("something went wrong","ERROR");
      }
    );
  }

  get email(){
    return this.editUserForm.get('Email') as FormControl;
  }
  
  createForm(userData:any){
    console.log(userData.username + userData.email + userData.password + userData.role);
    this.editUserForm = new FormGroup({
     
      Username:new FormControl(userData.username,[Validators.pattern("[a-zA-Z ]{8,25}"),Validators.required]),
      Email:new FormControl(userData.email,Validators.required),
      Password:new FormControl(userData.password,Validators.required),
      UserRole:new FormControl(userData.role,Validators.required),
    });
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
    console.log(this.editUserForm.getRawValue());
    this._adminUserService.updateUser(this.userId,this.editUserForm.getRawValue()).subscribe(
      data=>{
        if(data != null){
            this.toastr.success(data,"success");
            this._router.navigate(['/listUsers']);
        }else{
          this.toastr.warning(data,"Failure");
        }
  },
  err=>{
    this.toastr.error(err,"Error");
  })

  }

}