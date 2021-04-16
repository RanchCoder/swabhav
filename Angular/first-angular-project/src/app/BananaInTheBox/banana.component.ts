import {Component,Input,Output,EventEmitter} from '@angular/core';

@Component({
    selector:'banana-in-box',
    templateUrl:'./banana.component.html',
    
})

export class BananaComponent{
   public price !: string;
   public discount !: string;
   public finalBill !: number;
   public GenerateBill(){
      this.finalBill = (parseInt(this.price) *(parseFloat(this.discount)  / 100)) + parseInt(this.price);
      return this.finalBill;
   }
}
