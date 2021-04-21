import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Book } from '../_models/book';
import { of } from 'rxjs/internal/observable/of';
import { map } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Purchase } from '../_models/purchase';
import { Router } from '@angular/router';
import { typeSourceSpan } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  //Used to store API Url
  apiUrl = environment.apiUrl; //get api URL from enviroment variables

  //Used to store state. Array of Products
  products: Book[] = [];

  //Used to store Cart Items
  placeholder = [];

  //Behavior Subject to update total cart items in nav component. Passing empty array
  cartItems = new BehaviorSubject([])

  //Bring in HTTP Client 
  constructor(private router: Router,private http: HttpClient, private toastr: ToastrService) {
    //When app loads, attempt to retrieve cart items from Local Storage
    //Local storage returns string. So we need to Parse to JSON to retrieve object we can work with.
    const ls = this.getCartData();

    //Check if there is data stored here. Push data to our BehaviourSubject
    if(ls) this.cartItems.next(ls);
  }

  //Function to get products which returns a Book array
  getAllProducts() {
      /*
      If the product array has values in it already then return values from it
      else fetch values form API and return them.
      This way we limit the amount of API calls
      of: Means we are returning something of type Observable
      */
      if (this.products.length > 0) return of(this.products)//returns Observable
  
      //Else get from API
      //We will use TypeScript inference. Here we set the members inside pipe operator after getting them from API.
      return this.http.get<Book[]>(this.apiUrl + 'books').pipe(
        map(products => {
          this.products = products;
          return products;//map also returns an Observable.
        })
      );
    }

  getProduct(id: number)
  {
    //Attempt to get product from our products in array before trying service
    const product = this.products.find(x => x.id === id);

    if (product !== undefined) return of(product);

    //If we cant find the product then we will make our API call.
    return this.http.get<Book>(this.apiUrl + 'books/' + id)
  }

  addItem(product:Book)
  {
    //Get local storage object
    const ls = this.getCartData();

    const purchase: Purchase[] = [];

    //Storage for local storage data
    let exist: Book;

    //Check if item is already in cart
    if(ls)
    //Iterating through items in Cart
    exist = ls.find((item) =>{
      return item.id === product.id;
    });

    //Already in [localStorage]
    if(exist)
    {
      //Set to our local storage
      this.setCartData(ls);

      //Display error toast
      this.toastr.error(exist.bookName + ' already in cart!');
    }
    //Not in local [localStorage]
    else
    {
      //Product not in cart yet. Check if any other data is in local storage.
      if(ls)
      {
        //Combine the new item array to Product array
        const newData = [...ls, product];

        //Store new Product in local Storage
        this.setCartData(newData);

        //Display success toast
        this.toastr.success(product.bookName + ' added to cart!');
        
        //Emit the new data so it can be subscribed to from any other objects that we need.
        this.cartItems.next(this.getCartData());
      }
      //Nothing in local storage yet. So this will be the first item
      else
      {
        //Push Products to our placeholder object
        this.placeholder.push(product);

        //Set to our local storage
        this.setCartData(this.placeholder);

        //Display success toast
        this.toastr.success(product.bookName + ' added to cart!');

        //Emit the new data so it can be subscribed to from any other objects that we need.
        this.cartItems.next(this.getCartData());

      }
    }
  }

  //Function to clear entire cart
  emptyCart()
  {
        //Clear cart items
        this.placeholder = [];

        //Set update to our local storage
        this.setCartData(this.placeholder);

        //Display toast
        this.toastr.success('Cart cleared successfully!');

        //Emit the new data so it can be subscribed to from any other objects that we need.
        this.cartItems.next(this.getCartData());
  }

  //Function to remove Product from cart by ID
  removeCartItem(id: number): void {

    //Fetch Products from cart
    this.placeholder = this.getCartData();
     
    //Storage for Product to delete
    let toDelete: Book;

    //Check if item is already in cart
    if(this.placeholder)
    //Iterating through items in cart to find Product to delete
    toDelete = this.placeholder.find((item) =>{
      return item.id === id;
    });  
    
    //Product to delete found
    if(toDelete)
    {
      this.placeholder = this.placeholder.filter(item => item !== toDelete);
    }else
    {
      //Display toast
      this.toastr.error( 'Error Occured when trying to delete ' + toDelete.bookName );
    }

    //Set update to our local storage
    this.setCartData(this.placeholder);

    //Display toast
    this.toastr.success( toDelete.bookName + ' Removed Successfully');

    //Emit the new data so it can be subscribed to from any other objects that we need.
    this.cartItems.next(this.getCartData());
	}

  //Function to set local storage
  setCartData(data: any)
  {
    localStorage.setItem('cart', JSON.stringify(data));
  }

  //Function to get local storage data
  getCartData()
  {
    return JSON.parse(localStorage.getItem('cart'));
  }

  makePurchase() {

    //Get local storage object
    const ls = this.getCartData();

    //Make http post
    this.http.post(this.apiUrl + 'AppUserBook', ls)
        .subscribe(

            (val) => {
                console.log("POST call successful value returned in body", 
                            val);
            },
            response => {
                console.log("POST call in error", response);
            },
            () => {
                //Clear cart items
                this.placeholder = [];

                //Set update to our local storage
                this.setCartData(this.placeholder);

                //Route to thank you purchase page
                this.router.navigateByUrl('confirmation');

                //Emit the new data so it can be subscribed to from any other objects that we need.
                this.cartItems.next(this.getCartData());
            });
    }

}
