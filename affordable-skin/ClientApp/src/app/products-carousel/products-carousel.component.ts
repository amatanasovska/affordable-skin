import {Component, Input, OnInit} from '@angular/core';
import {Product} from "../models/product";


@Component({
  selector: 'app-products-carousel',
  templateUrl: './products-carousel.component.html',
  styleUrls: ['./products-carousel.component.css']
})
export class ProductsCarouselComponent implements OnInit {

  @Input() products : Product[] = []
  constructor() { }

  ngOnInit(): void {
  }

}
