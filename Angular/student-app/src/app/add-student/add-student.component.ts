import { Component, OnInit } from '@angular/core';
import {StudentService} from '../student.service';
@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddStudentComponent implements OnInit {

  constructor(private _studentService : StudentService) { }
  userInputData = {};
  ngOnInit(): void {
    this.postStudentData();
  }
 
  postStudentData(){
    this._studentService.addStudent();
  }

}
