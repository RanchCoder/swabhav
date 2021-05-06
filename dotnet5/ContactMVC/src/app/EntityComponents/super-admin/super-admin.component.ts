import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminUserService } from 'src/app/Services/admin-user.service';

@Component({
  selector: 'app-super-admin',
  templateUrl: './super-admin.component.html',
  styleUrls: ['./super-admin.component.css']
})
export class SuperAdminComponent implements OnInit {

  constructor(private _adminUserService : AdminUserService,private _router :Router,private _toastr:ToastrService) { }
  tenantsData : any[] = [];
  ngOnInit(): void {
    this._adminUserService.getTenants().subscribe(
      data=>{
        if(data != null){
          this.tenantsData = data;
        }
      }
    )
  }

  deleteTenant(tenantId:any){
      // console.log(tenantId);
      this._adminUserService.deleteTenant(tenantId).subscribe(data=>{
        if(data != null){
          this._toastr.success("Tenant deleted successfully");
          this._router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
            this._router.navigate(['super-admin-dashboard']);
           })
        }
      });
  }
  

}
