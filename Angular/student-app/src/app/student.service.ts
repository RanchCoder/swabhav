import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http : HttpClient) {

   }

    getStudentData():Observable<any[]>{
          return this.http.get<any>('http://gsmktg.azurewebsites.net:80/api/v1/techlabs/test/students/');
    }   

    addStudent(bodyData:any): Observable<any> {
      const headers = { 'content-type': 'application/json'}  
      const body = JSON.stringify(bodyData);
      console.log(body)
      return this.http.post('http://gsmktg.azurewebsites.net:80/api/v1/techlabs/test/students/', body,{'headers':headers});
    }
}