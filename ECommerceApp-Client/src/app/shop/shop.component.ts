import { Component, OnInit } from '@angular/core';
import { Brand } from '../shared/models/brand';
import { Product } from '../shared/models/product';
import { ProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/ShopParams';
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
  shopParams = new ShopParams();

  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },

  ]
  totalCount: number;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams)
      .subscribe(
        (res) => {
          this.products = res.data
          this.shopParams.pageNumber = res.pageIndex;
          this.shopParams.pageSize = res.pageSize;
          this.totalCount = res.count;
        },
        err => console.log(err)
      )
  }

  getBrands() {
    this.shopService.getBrands()
      .subscribe(
        res => {
          this.brands = [{ id: 0, name: 'All' }, ...res]
        },
        err => console.log(err))
  }

  getTypes() {
    this.shopService.getTypes()
      .subscribe(
        res => {
          this.types = [{ id: 0, name: 'All' }, ...res]
        },
        err => console.log(err))
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    this.shopParams.pageNumber = event.page;
    this.getProducts();
  }

}
