import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-custom-paging-header',
  templateUrl: './custom-page-header.component.html',
  styleUrl: './custom-page-header.component.scss'
})
export class CustomPageHeaderComponent {
  @Input() pageNumber!: number;
  @Input() pageSize!: number;
  @Input() totalCount!: number;

}
