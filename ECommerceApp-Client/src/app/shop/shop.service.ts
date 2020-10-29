import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from '../shared/models/brand';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { ProductType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:44375/api/';

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<Pagination<Product>>(this.baseUrl + 'products?pageSize=50')
  }


  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + 'products/brands')
  }

  getTypes() {
    return this.http.get<ProductType[]>(this.baseUrl + 'products/types')
  }
}
