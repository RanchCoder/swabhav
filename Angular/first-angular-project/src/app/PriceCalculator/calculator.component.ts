import {Component} from '@angular/core';

@Component({
    selector:'calculator',
    templateUrl:'./calculator.component.html'
})

export class CalculatorComponent{
    cost:number = 0;
    PriceCalculator(price:any,discount:any){
        this.cost = (parseInt(price) * parseFloat(discount)) + parseInt(price);
        return this.cost;
    }
}