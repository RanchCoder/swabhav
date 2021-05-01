import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CountryApiService {

  constructor(private http : HttpClient) { }

  getCountryData():Observable<any[]>{
      return this.http.get<any>('https://restcountries.eu/rest/v2/all');
  }
}
