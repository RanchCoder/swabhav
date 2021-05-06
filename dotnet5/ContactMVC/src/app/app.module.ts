import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactAddressService } from './Services/contact-address.service';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
// import { ViewAddressComponent } from './view-address/view-address.component';
 import { EditAddressComponent } from './EntityComponents/Address/edit-address/edit-address.component';
// import { AddAddressComponent } from './add-address/add-address.component';
// import { DeleteAddressComponent } from './delete-address/delete-address.component';
import { RegistrationComponent } from './AuthorizeAuthenticate/registration/registration.component';
import { LoginComponent } from './AuthorizeAuthenticate/login/login.component';
import { NavigationComponent } from './EntityComponents/navigation/navigation.component';
import { AuthGuard } from './AuthorizeAuthenticate/auth.guard';
import {ViewAddressComponent} from './EntityComponents/Address/view-address/view-address.component';
import { AdminComponent } from './EntityComponents/Admin_/admin/admin.component';
import { AddUserComponent } from './EntityComponents/User/add-user/add-user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {ShowContactsComponent} from './EntityComponents/Contact/show-contacts/show-contacts.component';
import {EditContactComponent} from './EntityComponents/Contact/edit-contact/edit-contact.component';
import {AddAddressComponent} from './EntityComponents/Address/add-address/add-address.component';
import { AddContactComponent} from './EntityComponents/Contact/add-contact/add-contact.component';
import { ToastrModule } from 'ngx-toastr';
import { DeleteContactComponent } from './EntityComponents/Contact/delete-contact/delete-contact.component';
import { EditUserComponent } from './EntityComponents/User/edit-user/edit-user.component';
import { AdminDashboardComponent } from './EntityComponents/Admin_/admin-dashboard/admin-dashboard.component';
//import { NumbersapiComponent } from './numbersapi/numbersapi.component';
//import { CountryComponent } from './country/country.component';
//import { CountryApiService } from './country-api.service';
import {TokenInterceptorService} from './AuthorizeAuthenticate/token-interceptor.service';

import {JwtModule} from '@auth0/angular-jwt';
import { SuperAdminComponent } from './EntityComponents/super-admin/super-admin.component';
import { SuperAdminLoginComponent } from './AuthorizeAuthenticate/super-admin-login/super-admin-login.component';

export function tokenGetter(){
  
  console.log(localStorage.getItem("jwt"));
  return localStorage.getItem("jwt");
}


@NgModule({
  declarations: [
    AppComponent,
    ShowContactsComponent,
   
    AddContactComponent,
    RegistrationComponent,
    LoginComponent,
    NavigationComponent,
    AdminComponent,
    AddUserComponent,
    EditContactComponent,
    DeleteContactComponent,
    ViewAddressComponent,
    AddAddressComponent,
    EditAddressComponent,
    EditUserComponent,
    AdminDashboardComponent,
    SuperAdminComponent,
    SuperAdminLoginComponent
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(),
    JwtModule.forRoot({
      config:{
        tokenGetter:tokenGetter,
        allowedDomains: ["localhost:5001","localhost:58500","contact-api.azurewebsites.net"],
        
      
      },
    }),
   
    ReactiveFormsModule
  ],
  providers: [ContactAddressService,AuthGuard,{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptorService,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
