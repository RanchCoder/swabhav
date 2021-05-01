import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountryComponent } from './country/country.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
//import { NumbersapiComponent } from './numbersapi/numbersapi.component';
import {AuthGuard} from '../app/auth.guard';
import { AddUserComponent } from './add-user/add-user.component';
import { AdminComponent } from './admin/admin.component';
import {AdminDashboardComponent} from './admin-dashboard/admin-dashboard.component';
import {ViewAddressComponent} from '../app/view-address/view-address.component';
import { ShowContactsComponent } from './show-contacts/show-contacts.component';
import { AddContactComponent } from './add-contact/add-contact.component';
import { EditContactComponent } from './edit-contact/edit-contact.component';
import {EditAddressComponent} from './edit-address/edit-address.component';
import {DeleteContactComponent} from './delete-contact/delete-contact.component';
import { AddAddressComponent} from './add-address/add-address.component';
import {EditUserComponent} from './edit-user/edit-user.component';
const routes: Routes = [
  {path:'',redirectTo:'/',pathMatch : 'full'},  
  {path:'listUsers',component:AdminComponent,canActivate:[AuthGuard]},
  {path:'showContacts/:userId',component:ShowContactsComponent,canActivate:[AuthGuard]},
  {path:'edit-contact/:userId/:contactId',component:EditContactComponent,canActivate:[AuthGuard]},
  {path:'addContact/:userId',component:AddContactComponent,canActivate:[AuthGuard]},
  {path:'address/:userId/:contactId',component:ViewAddressComponent,canActivate:[AuthGuard]},
  {path:'addUser',component:AddUserComponent,canActivate:[AuthGuard]},
  {path:'delete-contact/:userId/:contactId',component:DeleteContactComponent,canActivate:[AuthGuard]},
  {path:'login',component:LoginComponent,},
  {path:'dashboard',component:AdminDashboardComponent,},
  {path:'editAddress/:userId/:contactId/:addressId',component:EditAddressComponent,canActivate:[AuthGuard]},
  {path:'addAddress/:userId/:contactId',component:AddAddressComponent,canActivate:[AuthGuard]},
  {path:'registration',component:RegistrationComponent},
  {path:'edit-user/:userId',component:EditUserComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ onSameUrlNavigation: 'reload' })],
  
  exports: [RouterModule]
})
export class AppRoutingModule { }
