import { NgModule } from "@angular/core";
import { CustomPagerComponent } from "./components/custom-pager/custom-pager.component";
import { CommonModule } from "@angular/common";
import { PaginationModule } from 'ngx-bootstrap/pagination'; 
import { FormsModule } from "@angular/forms";
import { CustomPageHeaderComponent } from "./components/custom-page-header/custom-page-header.component";

@NgModule({
    declarations:[CustomPagerComponent, CustomPageHeaderComponent],
    imports:[CommonModule, PaginationModule, FormsModule],
    exports:[CustomPagerComponent, CustomPageHeaderComponent, CommonModule]
})
export class SharedModule{ }