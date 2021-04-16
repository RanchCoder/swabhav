import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {WelcomeComponent} from './Welcome/welcome.component';
import {StudentComponent} from './Student/student.component';
import { EventComponent } from './Event/event.component';
import { CalculatorComponent } from './PriceCalculator/calculator.component';
import { BananaComponent } from './BananaInTheBox/banana.component';
import { PropertyComponent } from './Binding/propertyBinding.component';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
   AppComponent,
   PropertyComponent,
   BananaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
