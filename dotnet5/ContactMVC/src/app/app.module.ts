import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowContactsComponent } from './show-contacts/show-contacts.component';
import { ShowAddressComponent } from './show-address/show-address.component';
import { ContactAddressService } from './contact-address.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AddContactComponent } from './add-contact/add-contact.component';
import { EditContactComponent } from './edit-contact/edit-contact.component';
import { DeleteContactComponent } from './delete-contact/delete-contact.component';
import { ViewAddressComponent } from './view-address/view-address.component';
import { EditAddressComponent } from './edit-address/edit-address.component';
//import { NumbersapiComponent } from './numbersapi/numbersapi.component';
//import { CountryComponent } from './country/country.component';
//import { CountryApiService } from './country-api.service';

@NgModule({
  declarations: [
    AppComponent,
    ShowContactsComponent,
    ShowAddressComponent,
    AddContactComponent,
    EditContactComponent,
    DeleteContactComponent,
    ViewAddressComponent,
    EditAddressComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [ContactAddressService],
  bootstrap: [AppComponent]
})
export class AppModule { }
