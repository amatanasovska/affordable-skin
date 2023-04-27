import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import {CarouselModule} from 'primeng/carousel';
import {ProductsCarouselComponent} from "./products-carousel/products-carousel.component";
import {ProductViewComponent} from "./product-view/product-view.component";
import {BrandProductsComponent} from "./brand-products/brand-products.component";
import {ProductPriceComponent} from "./product-price/product-price.component";
import {SearchComponent} from "./search/search.component";
import {ProductSearchResultComponent} from "./product-search-result/product-search-result.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductComponent,
    ProductsCarouselComponent,
    ProductViewComponent,
    BrandProductsComponent,
    ProductPriceComponent,
    SearchComponent,
    ProductSearchResultComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'view-product', component: ProductViewComponent},
      {path: 'list-brand-products/:name', component: BrandProductsComponent},
    ]),
    CarouselModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
