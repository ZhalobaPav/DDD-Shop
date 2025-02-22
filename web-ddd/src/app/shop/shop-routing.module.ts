import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ShopComponent } from "./shop.component";

const routes:Routes = [
    {path:'', component:ShopComponent}
]
@NgModule({
    declarations:[],
    imports:[
        RouterModule.forChild(routes)
    ],
    exports:[RouterModule]
})
export class ShopRoutingModule{

}