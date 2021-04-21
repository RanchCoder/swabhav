import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerLandingComponent } from './customer-landing/customer-landing.component';



@NgModule({
  declarations: [
    CustomerLandingComponent
  ],
  imports: [
    CommonModule
  ]
  ,
  exports:[
    CustomerLandingComponent
  ]
})
export class SecondCustomModule { }
