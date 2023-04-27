import {Component, Inject, Input, OnInit} from '@angular/core';
import {Product} from "../product";
import {ActivatedRoute} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {ProductPrice} from "../productPrice";

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
  @Input() product: Product = new Product();
  public http: HttpClient;
  public baseUrl: string;
  public latestProductPrices: ProductPrice[] = [];
  constructor(private _route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this._route.queryParams.subscribe(params => {
      this.product = JSON.parse(params.productToShow) as Product;
    });
    console.log(this.product)
    console.log(this.latestProductPrices)
    this.http.get<ProductPrice[]>(this.baseUrl + 'product/prices/latest/' + this.product.key).subscribe(result => {
      this.latestProductPrices = result;
      console.log(result)
    }, error => console.error(error));

  }

}
