//Interceptors will be initialised when we start application
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user';
import { take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  //Here we will inject our Account Service to get the user object
  constructor(private accountService: AccountService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser: User;

    //.take means we want to complete after receiving one of these users. No need to unsubscribe
    //If we are unsure if we need to unsubscribe from something. We just use pipe and take(1)
    //Once the user logs in, we will get the user object. So we wait and observe
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => currentUser = user)

    //Check if we have a current user inside there
    if (currentUser) {
      //Clone the above request and add our authentication header onto it.
      request = request.clone({
        setHeaders: {
          //This will attach our token for every request when we are logged in.
          Authorization: `Bearer ${currentUser.token}`
        }
      });
    }
    return next.handle(request);
  }
}
