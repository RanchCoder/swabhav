import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CustomModule} from '../app/custom/custom.module';
import {SecondCustomModule} from '../app/second-custom/second-custom.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CustomModule,
    SecondCustomModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
