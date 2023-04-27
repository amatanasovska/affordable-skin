import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Product} from "../models/product";

@Component({
  selector: 'app-product-search-result',
  templateUrl: './product-search-result.component.html',
  styleUrls: ['./product-search-result.component.css']
})
export class ProductSearchResultComponent implements OnInit {
  @Input() product: Product = new Product();
  @Output() onClicked = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
  }
  clicked():void
  {
    this.onClicked.emit();
  }
}
