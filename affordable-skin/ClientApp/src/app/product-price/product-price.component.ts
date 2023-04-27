import {Component, Input, OnInit} from '@angular/core';
import {ProductPrice} from "../productPrice";

@Component({
  selector: 'app-product-price',
  templateUrl: './product-price.component.html',
  styleUrls: ['./product-price.component.css']
})
export class ProductPriceComponent implements OnInit {

  @Input() public productPrice: ProductPrice = new ProductPrice();
  constructor() { }

  ngOnInit(): void {
  }

}
