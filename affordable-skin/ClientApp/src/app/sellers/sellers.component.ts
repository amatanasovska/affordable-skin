import {Component, Inject, OnInit} from '@angular/core';
import {Brand} from "../models/brand";
import {HttpClient} from "@angular/common/http";
import {Seller} from "../models/seller";

@Component({
  selector: 'app-sellers',
  templateUrl: './sellers.component.html',
  styleUrls: ['./sellers.component.css']
})
export class SellersComponent implements OnInit {
  public sellers: Seller[] = []
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Seller[]>(baseUrl + 'sellers').subscribe(result => {
      this.sellers = result;
    }, error => console.error(error));
  }
  ngOnInit(){

  }

}
