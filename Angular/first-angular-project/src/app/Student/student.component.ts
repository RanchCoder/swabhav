import{Component} from "@angular/core";
import {IStudent} from './IStudent';
@Component({
    selector: 'student-data',
    templateUrl: './student.component.html',
    styleUrls:['./student.component.css']
})


export class StudentComponent {
     students:IStudent[] = [];
     public loadData(){
         this.students = [
             {             
               sname:"vishal",
               sage:15,
               cgpa:4.5,
               
         },
         {             
            sname:"prem",
            sage:13,
            cgpa:4.5,
      },
        ];
     }

     public loadParticularStudent(name:string,age:string,cgpa:string){

       this.students = [{
         sname:name,
         sage:parseInt(age),
         cgpa:parseInt(cgpa)
       }];


     }
  }
  
  

