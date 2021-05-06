import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminUserService } from '../../../Services/admin-user.service';
import { User } from '../../../DTO/User';
import {Location} from '@angular/common';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private _location : Location,private _adminUserService : AdminUserService,private router : Router,private toastr : ToastrService) { }

  usersData : any[] = [];
  responseMessage : any;
  toggle : boolean = false;
  ngOnInit(): void {
    this._adminUserService.getUsers().subscribe(
      data=>{
        if(data.length > 0){
          this.usersData = data;
       
        }else{
          this.toastr.success("No users to display");
          
        }
      },
      err=>{
        this.toastr.error("You do not have access to the content","Access Denied");
        this._location.back();
      }
    );
  }

  changeColor(){
    this.toggle = !this.toggle;
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

 

  addOrRemoveFavorite(userId:any){
       this._adminUserService.addUserToFavorite(userId).subscribe(
         data=>{
           if(data != null){             
          
           this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
            this.router.navigate(['/listUsers']);
           })
           }
           else{
             this.toastr.warning("Cannot add user to favorite");
           }
         },
         
       );
  }

}
