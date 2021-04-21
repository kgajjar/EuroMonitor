import { Component } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Euromonitor International Book Store';
  //This is how we turn off type safety. Users can be anything.
  users: any;

  //Http service to make this request. Bring account service in here as well.
  constructor(private accountService: AccountService) { }

  //Implement OnInit
  ngOnInit() {

    //Call Set current user from the service
    this.setCurrentUser();
  }

  setCurrentUser() {
    //Parse to get JSON out of stringified form into user object here.
    const user: User = JSON.parse(localStorage.getItem('user'))
    this.accountService.setCurrentUser(user);
  }
}
