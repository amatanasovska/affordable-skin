import {Component, Inject} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Product} from "../product";
import {Brand} from "../brand";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public brands: Brand[] = []
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Brand[]>(baseUrl + 'brand').subscribe(result => {
      this.brands = result;
    }, error => console.error(error));
  }

}

