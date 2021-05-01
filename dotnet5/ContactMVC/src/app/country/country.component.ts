import { Component, OnInit } from '@angular/core';
import {CountryApiService} from '../Services/country-api.service';
@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {

  constructor(private _countryApiService : CountryApiService) { }
  countryData : any[] = [];
  ngOnInit(): void {
    this.fetchCountryData();
  }

   fetchCountryData(){
        this._countryApiService.getCountryData().subscribe(data=>{
         this.countryData = data; 
        })
   }
}
