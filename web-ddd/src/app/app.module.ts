import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { HomeModule } from "./home/home.module";
import { AppRoutingModule } from "./app.routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from "./core/nav-bar/nav-bar.component";

@NgModule({
    declarations:[AppComponent],
    imports: [
    HomeModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    NgbModule,
    NavBarComponent
],
    bootstrap:[AppComponent]
})
export class AppModule{

}