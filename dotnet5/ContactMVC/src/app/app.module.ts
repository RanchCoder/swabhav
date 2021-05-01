import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactAddressService } from './contact-address.service';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
// import { ViewAddressComponent } from './view-address/view-address.component';
 import { EditAddressComponent } from './edit-address/edit-address.component';
// import { AddAddressComponent } from './add-address/add-address.component';
// import { DeleteAddressComponent } from './delete-address/delete-address.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { NavigationComponent } from './navigation/navigation.component';
import { AuthGuard } from './auth.guard';
import {ViewAddressComponent} from './view-address/view-address.component';
import { AdminComponent } from './admin/admin.component';
import { AddUserComponent } from './add-user/add-user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {ShowContactsComponent} from '../app/show-contacts/show-contacts.component';
import {EditContactComponent} from '../app/edit-contact/edit-contact.component';
import {AddAddressComponent} from '../app/add-address/add-address.component';
import { AddContactComponent} from '../app/add-contact/add-contact.component';
import { ToastrModule } from 'ngx-toastr';
import { DeleteContactComponent } from './delete-contact/delete-contact.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
//import { NumbersapiComponent } from './numbersapi/numbersapi.component';
//import { CountryComponent } from './country/country.component';
//import { CountryApiService } from './country-api.service';
import {TokenInterceptorService} from './token-interceptor.service';

import {JwtModule} from '@auth0/angular-jwt';

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
    AdminDashboardComponent
  
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
        allowedDomains: ["localhost:5001","localhost:58500"],
        
      
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
