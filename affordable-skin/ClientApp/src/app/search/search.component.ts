import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Product} from "../models/product";
import {Brand} from "../models/brand";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public searchQuery: string = "";
  public searchResults: Product[] = [];
  public show: boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  ngOnInit() {
  }

  search() {
    if(this.searchQuery.length>2) {
      this.show = true;
      this.http.get<Product[]>(this.baseUrl + 'product/search?query=' + this.searchQuery).subscribe(result => {
        this.searchResults = result;
        console.log(this.searchResults)
      }, error => console.error(error));
    }
    else
    {
      this.show = false;
    }

  }
  hideDropdown(){
    setTimeout(()=>
    {
      this.show=false;
    },100)

  }

}
