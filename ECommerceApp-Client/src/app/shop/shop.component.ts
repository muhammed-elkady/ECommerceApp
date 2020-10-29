import { Component, OnInit } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: Product[];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.shopService.getProducts()
      .subscribe(
        (res) => this.products = res.data,
        err => console.log(err)
      )
  }

}
