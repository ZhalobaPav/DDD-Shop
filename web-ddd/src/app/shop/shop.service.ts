import { Injectable } from '@angular/core';
import { ICatalogItem } from '../shared/models/catalog-item';
import { IBrand } from '../shared/models/brand';
import { ICategory } from '../shared/models/category';
import { ShopParams } from '../shared/models/shop-params';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs';
import { IPagination, Pagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:7176/api/';
  products: ICatalogItem[] = [];
  brands: IBrand[] = [];
  categories: ICategory[] = [];
  pagination:Pagination|null = new Pagination();
  shopParams: ShopParams = new ShopParams();

  getProducts(){
    let params: HttpParams = new HttpParams();

    if (this.shopParams.brandId !== 0) {
      params = params.append('brandId', this.shopParams.brandId.toString());
    }

    if (this.shopParams.typeId !== 0) {
      params = params.append('typeId', this.shopParams.typeId.toString());
    }

    params = params.append('PageNumber', this.shopParams.pageNumber.toString());
    params = params.append('PageSize', this.shopParams.pageSize.toString());
    return this.http.get<IPagination>(this.baseUrl+'CatalogItems', {observe:'response', params})
      .pipe(
        map(response=> {
          this.products = [...this.products, ...response!.body!.catalogItems];
          this.pagination = response.body;
          console.log(this.pagination)
          return this.pagination;
        })
      )
  }

  constructor(private http:HttpClient) { }

  getShopParams() {
    return this.shopParams;
  }

  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }
}
