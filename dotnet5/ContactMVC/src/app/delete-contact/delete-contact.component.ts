import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactAddressService } from '../contact-address.service';

@Component({
  selector: 'app-delete-contact',
  templateUrl: './delete-contact.component.html',
  styleUrls: ['./delete-contact.component.css']
})
export class DeleteContactComponent implements OnInit {

  constructor(private _contactService:ContactAddressService,private activatedRoute : ActivatedRoute) { }
  id : any;
  responseData : any;
  ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.paramMap.get('id') || '';
    this.sendDeleteRequest(this.id);
  }

  sendDeleteRequest(contactId:any){
    this._contactService.deleteContact(contactId).subscribe(data=>{
          console.log(data);
           this.responseData = data;
          
    });
  }

}
