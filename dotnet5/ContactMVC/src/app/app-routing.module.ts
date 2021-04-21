import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddContactComponent } from './add-contact/add-contact.component';
import { CountryComponent } from './country/country.component';
import { DeleteContactComponent } from './delete-contact/delete-contact.component';
import { EditAddressComponent } from './edit-address/edit-address.component';
import { EditContactComponent } from './edit-contact/edit-contact.component';
//import { NumbersapiComponent } from './numbersapi/numbersapi.component';
import { ShowAddressComponent } from './show-address/show-address.component';
import {ShowContactsComponent} from './show-contacts/show-contacts.component';
import { ViewAddressComponent } from './view-address/view-address.component';
const routes: Routes = [
  {path:'contacts',component:ShowContactsComponent},
  {path:'addcontact',component:AddContactComponent},
  {path:'edit-contact/:id',component:EditContactComponent},
  {path:'delete-contact/:id',component:DeleteContactComponent},
  {path:'address/:id',component:ViewAddressComponent},
  {path:'editAddress',component:EditAddressComponent},
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
