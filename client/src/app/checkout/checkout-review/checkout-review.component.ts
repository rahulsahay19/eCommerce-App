import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent implements OnInit {

  constructor(private basketService: BasketService, private toastr: ToastrService) { }

  ngOnInit() {
  }

  createPaymentIntent() {
    return this.basketService.createPaymentIntent()
              .subscribe((response: any) => {
                this.toastr.success('Payment intent created');
              }, error => {
                this.toastr.error(error.message);
              });
  }

}
