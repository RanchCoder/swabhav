import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.scss']
})
export class StarComponent implements OnInit {

  @Input() rating !:number;
  @Output() ratingEvent = new EventEmitter<number>();
   constructor() { 
     console.log(this.rating);
     this.ratingEvent.emit(this.rating);
   }
 
   ngOnInit(): void {
   }
}
