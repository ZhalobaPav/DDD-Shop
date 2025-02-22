import { Component } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { RouterModule } from '@angular/router';
import { IBasket } from '../../shared/models/basket';
import { Observable } from 'rxjs';
import { IUser } from '../../shared/models/user';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [SharedModule, RouterModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {
  basket$!: Observable<IBasket>;
  currentUser$!: Observable<IUser>;

  logout(){
    console.log('logout');
  }


}
