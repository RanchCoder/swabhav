import { Component, OnInit } from '@angular/core';
import {StudentService } from '../student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

  constructor(private _studentService : StudentService) { }
  studentData : any[] = [];
  ngOnInit(): void {
    this.fetchStudentData();
  }
   fetchStudentData(){
     this._studentService.getStudentData().subscribe(data=>{
       this.studentData = data;
     })

   }
}
