import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { debounceTime, tap } from 'rxjs/operators'; 
import { walkUpBindingElementsAndPatterns } from 'typescript';
import { AuthService } from '../../Services/auth.service';
import { Registration } from '../../DTO/Registration';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  countIfEmailIsTaken: number = 1;

  constructor(private httpClient : HttpClient, private authService : AuthService) { }
  companyNameInput :any;
  registrationForm :any;
  responseMessage :any;
  private readonly countIfUsernameIsTaken = 1;
  ngOnInit(): void {
     this.registrationForm = new FormGroup({
       CompanyName:new FormControl(null,[Validators.pattern("[a-zA-Z ]{8,25}"),Validators.required]),
       CompanyStrength:new FormControl(null,Validators.required),
       
       CompanyEmail:new FormControl(null,[Validators.email,Validators.required]),
       Username:new FormControl(null,[Validators.pattern("[a-zA-Z ]{8,25}"),Validators.required]),

       Password:new FormControl(null,Validators.required),
       ConfirmPassword:new FormControl(null,Validators.required),
     });

  }
  
   get companyName(){
     return this.registrationForm.get('CompanyName') as FormControl;
   }

   get password(){
     return this.registrationForm.get('Password') as FormControl;
   }

   get confirmPassword(){
     return this.registrationForm.get('ConfirmPassword') as FormControl;
   }

   get email(){
     return this.registrationForm.get('CompanyEmail') as FormControl;
   }

   checkCompanyName(inputText:any){
     
     
     if(inputText.target.value.length > 0){
      
       this.authService.validateCompanyName(inputText.target.value)
     .subscribe(
       dataCount=>{
        
         if(dataCount >= this.countIfUsernameIsTaken){
           
       
           this.companyName.setErrors({'notAvailable':true});
         }
       },
       err=>{
         this.companyName.setErrors({invalid:true});
       });
     }
          
   }

   validateEmail(event:any){
     if(event.target.value != null){
       this.authService.validateEmail(event.target.value).subscribe(
         dataCount=>{
             if(dataCount >= this.countIfEmailIsTaken){
               this.email.setErrors({'notAvailable':true});
             }
         },
         err=>{
           this.email.setErrors({invalid:true});
         }
       );
     }
   }

   validatePassword(passwordInput:any){
      if(passwordInput.target.value !== this.password.value){
        this.confirmPassword.setErrors({'notMatching':true});
      }else{
        this.confirmPassword.valid;
      }

   }

   onSubmit(){
     console.log(this.registrationForm.value);
     let registerUser = new Registration();
     registerUser.username = this.registrationForm.value.Username;
     registerUser.companyName = this.registrationForm.value.CompanyName;
     registerUser.companyEmail = this.registrationForm.value.CompanyEmail;
     registerUser.password = this.registrationForm.value.Password;
     registerUser.companyStrength = this.registrationForm.value.CompanyStrength;
     this.authService.registerUser(registerUser).subscribe(
     data=>this.responseMessage = data,
     err=>this.responseMessage = err
     );

   }
}
