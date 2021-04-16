import {Component} from "@angular/core";

@Component({
    selector:'property-binder',
    templateUrl:'./propertyBinding.component.html'
})

export class PropertyComponent{
     public username : string = "hello";
     public password : string = "";


}