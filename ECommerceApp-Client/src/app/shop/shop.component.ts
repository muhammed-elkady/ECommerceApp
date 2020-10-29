import { Component, OnInit } from '@angular/core';
import { Brand } from '../shared/models/brand';
import { Product } from '../shared/models/product';
import { ProductType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: Product[];
  brands: Brand[];
  types: ProductType[];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts()
      .subscribe(
        (res) => this.products = res.data,
        err => console.log(err)
      )
  }

  getBrands() {
    this.shopService.getBrands()
      .subscribe(
        res => this.brands = res,
        err => console.log(err))
  }

  getTypes() {
    this.shopService.getTypes()
      .subscribe(
        res => this.types = res,
        err => console.log(err))
  }

}
