import {Component, Inject, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Product} from "../models/product";

@Component({
  selector: 'app-brand-products',
  templateUrl: './brand-products.component.html',
  styleUrls: ['./brand-products.component.css']
})
export class BrandProductsComponent implements OnInit {

  public brandName: string | undefined;
  public products: Product[] = [];
  public http: HttpClient;
  public baseUrl: string;
  constructor(private route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.brandName = this.route.snapshot.params['name'];
    this.http.get<Product[]>(this.baseUrl + 'product/' + this.brandName).subscribe(result => {
      this.products = result;
      console.log(result)
    }, error => console.error(error));
  }

}
