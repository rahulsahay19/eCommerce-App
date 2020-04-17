import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
   title = 'My View - Store';
   constructor(private basketService: BasketService) {}

   ngOnInit(): void {
     const basketId = localStorage.getItem('basket_id');
     if (basketId) {
       this.basketService.getBasket(basketId).subscribe(() => {
        console.log('Initialized basket');
       }, error => console.log(error));
     }
   }
}
