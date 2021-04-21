import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Book } from '../_models/book';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

products : Book[];

constructor(private cartSvc: CartService) {}
//Assign data returned from our Observable to a Property called products
ngOnInit()
{
  this.cartSvc.cartItems.subscribe(cartitems => {
    //Get all items in cart
    this.products = cartitems;
  })
}

_emptyCart()
{
  this.cartSvc.emptyCart();
}

_removeCartItem(id: number)
{
  this.cartSvc.removeCartItem(id);
}
}