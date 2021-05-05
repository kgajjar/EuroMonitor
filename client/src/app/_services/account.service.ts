import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from '../_models/user';
import { Register } from '../_models/register';
import { ToastrService } from 'ngx-toastr';

//Injectable means that this service can be injected in other components/services in app
@Injectable({
  providedIn: 'root'
})
//Data inside service gets destroyed when browser closed
export class AccountService {
  
  //Make request to Login endpoint
  baseUrl = environment.apiUrl;//get api URL from enviroment variables

  //Store our user in a special observable called a ReplaySubject.
  //Anytime someone subscribes to this observable it will emit the last value inside it.
  //We want to store User in this ReplaySubject
  //We tell it how many previous values we want to store.
  private currentUserSource = new ReplaySubject<User>(1)//1 is size of our buffer. Singleton.

  //This will be an observable so we give it $ at the end
  currentUser$ = this.currentUserSource.asObservable();

  //Inject http client into account service
  constructor(private http: HttpClient, private toastr: ToastrService) { }

  //model type if any. Send body to server.
  login(model: any) {
    //Here we use the pipe operator so we can do something with the response we get back from http req.
    return this.http.post(this.baseUrl + 'account/login', model)
      .pipe(

        //Here we return response in User interface
        map((response: User) => {
          //Here we work with the response of http req

          //Get user from response
          const user = response;

          //Check if user was returned
          if (user) {
            //Add user to local storage and stringify it
            localStorage.setItem('user', JSON.stringify(user));

            //Set the observable to current user we get back from API
            this.currentUserSource.next(user);
          }
        })
      );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      //Do something before returning response. We could use any for this too.But we have User Object.
      map((user: User) => {
        //If user exists in object
        if (user) {
          //Store user obj in local storage
          localStorage.setItem('user', JSON.stringify(user));

          this.toastr.success("Welcome " + user.username);

          //Store it in Observable
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }

  //Helper method
  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  //Remove from local storage
  logout() {
    localStorage.removeItem('user');
    //Clear observable
    this.currentUserSource.next(null);
  }
}
