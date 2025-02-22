import { NgModule } from "@angular/core";
import { ShopComponent } from "./shop.component";
import { CommonModule } from "@angular/common";
import { ProductItemComponent } from "./product-item/product-item.component";
import { ShopRoutingModule } from "./shop-routing.module";
import { SharedModule } from "../shared/shared.module";

@NgModule({
    declarations:[ShopComponent, ProductItemComponent],
    imports:[
        CommonModule,
        ShopRoutingModule,
        SharedModule
    ]
})
export class ShopModule {
    
}