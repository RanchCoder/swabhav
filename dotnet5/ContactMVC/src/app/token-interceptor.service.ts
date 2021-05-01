import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

  constructor(private _router : Router) { }

  intercept(req:HttpRequest<any>,next:HttpHandler):Observable<HttpEvent<any>>{
        
    if(localStorage.getItem("jwt") != null){
      req = req.clone({
          
        setHeaders:{
          'token': localStorage.getItem("jwt"),
        },
      });
      
    } 

    return next.handle(req).pipe(
      catchError((err:HttpErrorResponse)=>{
        if(err.status === 401){
          this._router.navigateByUrl("");
        }
        return throwError(err);
      }),
      
      
    );
    
  }
}
