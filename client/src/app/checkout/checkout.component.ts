import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
   
  }

}
