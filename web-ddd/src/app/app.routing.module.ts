import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { ShopComponent } from "./shop/shop.component";

export const routes: Routes = [
    {path:'', pathMatch:"full", component:ShopComponent},
    {path:'shop', loadChildren:()=>import('./shop/shop.module').then(mod=>mod.ShopModule)}
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }