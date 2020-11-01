import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from '../shared/models/brand';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { ProductType } from '../shared/models/productType';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:44375/api/';

  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number, sort?: string) {

    let params = new HttpParams();
    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }
    if (sort) {
      params = params.append('sort', sort);
    }

    return this.http.get<Pagination<Product>>(this.baseUrl + 'products',
      { observe: 'response', params })
      .pipe(
        map(res => res.body)
      )
  }


  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + 'products/brands')
  }

  getTypes() {
    return this.http.get<ProductType[]>(this.baseUrl + 'products/types')
  }
}
