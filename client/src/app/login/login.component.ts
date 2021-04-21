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

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {

  }

   login() {
    //Call the service
    this.accountService.login(this.model).subscribe(response => {

      //Send user to homepage
      this.router.navigateByUrl('cart');

    }, error => {
      //Output toastr
      //this.toastr.error(error.error);
    });
  }

}
