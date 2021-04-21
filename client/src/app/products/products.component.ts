import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Book } from '../_models/book';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

   //We make it an Observable
  products$: Observable<Book[]>

  constructor(private cartSvc: CartService) {}

  ngOnInit(): void {
    this.products$ = this.cartSvc.getAllProducts();
  }

  addToCart(product: Book)
  {
    this.cartSvc.addItem(product);
  }
}
