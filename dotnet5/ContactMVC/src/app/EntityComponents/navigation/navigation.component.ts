import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  userId: string;
  userName: string;

  constructor(public _authService : AuthService,private jwtHelper : JwtHelperService) { 
   
  }
  companyName : any;
  userRole : any;
  
  ngOnInit(): void {
    
    this.initializeWebData();
    
  }

  initializeWebData(){
    if(this._authService.loggedIn()){
      
      let token = localStorage.getItem("jwt");
      let tokenPayLoad = this.jwtHelper.decodeToken(token);        
      
      
      this.companyName = this._authService.getTenantNameFromToken();
     
      this.userId = this._authService.getUserIdFromToken();

      this.userRole = this._authService.getUserRoleFromToken();
      this.userName = this._authService.getUserNameFromToken();
      
      
    }
  }
  

  isAdmin(){
    if(this.userRole != null && this.userRole == 'Admin'){
      return true;
    }else{
      return false;
    }
  }

  
}
