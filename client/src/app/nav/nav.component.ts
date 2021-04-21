import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  //Cart count storage
  itemsinCart:number;

  //Object is null by default
  model: any = {}

  constructor(public cartSvc: CartService, private toastr: ToastrService, public accountService: AccountService, private router: Router) {}

  //Assign data returned from our Observable to a Property called itemsinCart
  ngOnInit(): void
  {
    this.cartSvc.cartItems.subscribe(d => {
      //Get total amount of items in cart
      this.itemsinCart = d.length;
    })
  }

  //Function to log user out
  logout() {
    //Log user our
    this.accountService.logout();

    //Send user to home page after logout.
    this.router.navigateByUrl('/');
  }
}
