import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute ,ParamMap,Router} from '@angular/router';
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  productName: any;

  constructor(private http:HttpClient,private activatedRoute:ActivatedRoute,private router : Router) { }
  productId:any;
  productList = [];
  productData : any;
  ngOnInit(): void {
   this.activatedRoute.paramMap.subscribe((param:ParamMap)=>{
     this.productId = param.get('productId');
     this.fetchProductData();
     
   })
  }
  async fetchProductData(){
         this.http.get<any>('assets/productData/products.json').subscribe(
           data=>{
              if(data.length > 0){
                this.productList = data;
                this.getProductDataById(this.productId);
              
              }
           },
           err=>{
             console.log(err);
           }
         )
  }

  getProductDataById(productId){
      this.productData = this.productList.filter(item=>item.productId == productId);
      this.productName = this.productData[0]["productName"];
      
  }

}
