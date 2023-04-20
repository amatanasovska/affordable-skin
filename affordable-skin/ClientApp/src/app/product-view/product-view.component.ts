import {Component, Input, OnInit} from '@angular/core';
import {Product} from "../product";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
  @Input() product: Product = new Product()
  constructor(private _route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this._route.queryParams.subscribe(params => {
      this.product = JSON.parse(params.productToShow) as Product;
    });

  }

}
