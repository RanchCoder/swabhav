import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import {Pipe,PipeTransform} from '@angular/core';
@Pipe({
  name:'snakePipe',
})

export class SnakeComponent implements OnInit,PipeTransform {

  constructor() { }
  transform(value: any) {
    let array :string[] = [];
    array = value.split(" ");
    
    return array.join("_");
    
    
  }

  ngOnInit(): void {
  }



}
