import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Book } from '../_models/book';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-product-desc',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  product : Book;

  constructor(private cartSvc: CartService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.loadProduct();
  }

  //Function to load Product
  loadProduct() {
    //We access the id passed in route. Over here
    this.cartSvc.getProduct(+this.route.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
    })
  }

  //Function to add Product to cart
  addToCart(product: Book)
  {
    this.cartSvc.addItem(product);
  }
}
