import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  constructor(private http : HttpClient,private router : Router) { }
  productList : any = [];
  filterInput : any;
  filteredList : any = [];
  showHide : boolean = true;
  ngOnInit(): void {
         this.intializeList();
         
    
  }

  intializeList(){
    this.http.get<any>('assets/productData/products.json').subscribe(data=>{
      
      this.productList = data;
      this.filteredList = this.productList;
    });
  

  }

  filterListData(inputText){
    if(inputText.target.value == null || inputText.target.value == ""){
      console.log("filter cannot be done");
      //this.filteredList = this.filteredList.filter(item=> item.productName.indexOf(inputText.target.value) != -1);
    
        this.filteredList = this.productList;
        
    }else{
         console.log("yes filtering needed");
         this.filteredList = this.productList.filter(item=> item.productName.toLowerCase().indexOf(inputText.target.value.toLowerCase()) != -1);
    }
  }

  visibility(){
    if(this.showHide){
      this.showHide = false;
    }else{
      this.showHide = true;
    }
    
  }

}
