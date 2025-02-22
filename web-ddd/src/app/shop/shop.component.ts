import { Component, OnInit } from '@angular/core';
import { ICatalogItem } from '../shared/models/catalog-item';
import { ShopService } from './shop.service';
import { ShopParams } from '../shared/models/shop-params';

@Component({
  selector: 'app-shop',
  standalone: false,
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit{
  products: ICatalogItem[] = [];
  totalCount!: number;
  shopParams: ShopParams = new ShopParams();

  constructor(private shopService:ShopService){}

  ngOnInit(){
    console.log(`pageSize: ${this.shopParams.pageSize}`);
    this.getProducts();
  }
  
  getProducts(){
    this.shopService.getProducts().subscribe(response=>{
      this.products = response!.catalogItems;
      this.totalCount = response!.totalItems;
      console.log(this.totalCount)
    },err=>console.log(err));
  }

  onPageChanged(event: any){
    const params = this.shopService.getShopParams();
    if(params.pageNumber !== event){
      params.pageNumber = event;
      this.shopService.setShopParams(params);
      this.getProducts();
    }
  }

  onReset() {
    this.shopParams = new ShopParams();
    this.shopService.setShopParams(this.shopParams);
    this.getProducts();
  }
}
