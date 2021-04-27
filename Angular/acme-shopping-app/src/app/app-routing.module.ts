import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent} from './product/product-list/product-list.component';
import { WelcomeComponent } from './welcome/welcome.component';
import {ProductDetailComponent} from './product/product-detail/product-detail.component';

const routes: Routes = [
  {path:'',redirectTo:'/home',pathMatch:'full'},
  {path:'home',component:WelcomeComponent},
  {path:'product-list',component:ProductListComponent},
  {path:'product-detail/:productId',component:ProductDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
