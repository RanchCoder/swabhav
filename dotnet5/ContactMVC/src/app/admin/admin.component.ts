import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminUserService } from '../admin-user.service';
import { User } from '../User';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private _adminUserService : AdminUserService,private router : Router,private toastr : ToastrService) { }

  usersData : any[] = [];
  responseMessage : any;
  ngOnInit(): void {
    this._adminUserService.getUsers().subscribe(
      data=>{
        if(data.length > 0){
          this.toastr.success("showing list of users", "Users");
          console.log(data);
          this.usersData = data;
       
        }else{
          this.toastr.success("No users to display");
          
        }
      },
      err=>{
        this.toastr.error("Something went wrong","error");
      }
    );
  }

  editUser(user:User){

  }

  deleteUser(userId:any){
    this._adminUserService.deleteUser(userId).subscribe(
      data=>{
        if(data != null){
          this.toastr.info("user deleted","SUCCESS");
          location.reload();
          
        }else{
          this.toastr.warning("cannot delete user account");
        }
      },
      err=>{
        this.toastr.error(err);
      }
    );
 
  }

  ShowContactsForUser(userId:any){
    this._adminUserService.getUserContact(userId).subscribe(
      data=>{
         this.router.navigate(['/showContacts',userId],{state:{data:data}});
      }
    );
  }

}
