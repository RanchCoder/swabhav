
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'ag-form',
  templateUrl: './form.component.html',
})
export class FormComponent implements OnInit {

  loginForm!:FormGroup;
  username!:FormControl;
  password!: FormControl;

  ngOnInit() {
    this.createFormControls();
    this.createForm();
  }

   
createFormControls():void{
    this.username = new FormControl('', Validators.required);
    this.password = new FormControl('', Validators.required);
  }

  createForm() { 
    this.loginForm = new FormGroup({
      username: this.username,
      password: this.password
    });
  }
}
