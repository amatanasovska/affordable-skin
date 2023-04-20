import {Component, Inject} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Product} from "../product";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public products: Product[] = []
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

}

