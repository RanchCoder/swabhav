import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AdminUserService } from '../admin-user.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  companyStrength: any;

  constructor(private adminUserService : AdminUserService,private toastr : ToastrService, private authService : AuthService) { }

  userCount:any;  
  contactCount:any;
  addressCount:any;

  ngOnInit(): void {
     //location.reload();
     this.adminUserService.getCountData().subscribe(data=>{
       this.addressCount = data.addressCount;
       this.contactCount = data.contactCount;
       this.userCount  = data.userCount;
       this.companyStrength = data.companyStrength;
       this.toastr.success(`Welcome ${this.authService.getUserNameFromToken()}`);
     });      
  }

}
