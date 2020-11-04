import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product: Product;

  constructor(private shopService: ShopService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    let id = +this.activatedRoute.snapshot.paramMap.get('id');
    this.shopService.getProduct(id)
      .subscribe(res => {
        this.product = res;
      },
        err => {
          console.log(err)
        })
  }
}
