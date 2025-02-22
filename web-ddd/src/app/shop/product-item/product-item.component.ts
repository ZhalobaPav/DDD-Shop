import { Component, Input } from '@angular/core';
import { ICatalogItem } from '../../shared/models/catalog-item';

@Component({
  selector: 'app-product-item',
  standalone: false,
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss'
})
export class ProductItemComponent {
  @Input() product!: ICatalogItem;

}
