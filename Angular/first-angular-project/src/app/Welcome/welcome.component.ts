
import { Component } from '@angular/core';
import {SnakeComponent} from  '../snake-component/snake-component.component';
@Component({
  selector: 'welcome-greet',
  templateUrl: './welcome.component.html',
  
})
export class WelcomeComponent {
  title = 'first-angular-project';
  message:string = "good morning teacher";
}



