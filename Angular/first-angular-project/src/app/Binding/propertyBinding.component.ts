import {Component} from "@angular/core";

@Component({
    selector:'property-binder',
    templateUrl:'./propertyBinding.component.html'
})

export class PropertyComponent{
     public username : string = "hello";
     public password : string = "";

     public address!:string;
     public passport!:string;

     fetchAddress(addressEvent:any){
        return this.address = addressEvent;
     }

    fetchPassport(passport:string){
       return this.passport =  passport;
    }
 
}