import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //Object is null by default
  model: any = {}

  //Used to store validation errors
  validationErrors: string[] = [];

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {

  }

   login() {
    //Call the service
    this.accountService.login(this.model).subscribe(response => {

      //Send user to homepage
      this.router.navigateByUrl('cart');

    }, error => {
       //Take care of validation errors on client + backend. Just in case there is a mismatch
      //Set validation errors to error we get back from API
      this.validationErrors = error;
    });
  }

}
