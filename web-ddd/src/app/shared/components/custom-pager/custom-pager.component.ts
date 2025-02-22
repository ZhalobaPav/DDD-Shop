import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-custom-pager',
  templateUrl: './custom-pager.component.html',
  styleUrl: './custom-pager.component.scss'
})
export class CustomPagerComponent {
  @Input() totalCount!: number;
  @Input() pageSize!: number;
  @Input() pageNumber!: number;
  @Output() pageChanged = new EventEmitter<number>();

  onPagerChange(event: any) {
    this.pageChanged.emit(event.page);
  }
}
