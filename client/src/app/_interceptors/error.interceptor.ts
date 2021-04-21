import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  //Adding Router : So we can redirect the user
  //Adding Toast: So we can display Toastr notifcation
  constructor(private router: Router, private toastr: ToastrService) { }

  //Here we can do 2 things:
  //1) We can intercept the request that goes out
  //2) Or we can intercept the response that comes back in the (next) param below which handles the response that comes out.
  intercept(request: HttpRequest<unknown>, next: HttpHandler): /*This is what we get back*/Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      //Use RXJS feature
      catchError(error => {
        //Check if we even have an error here
        if (error) {
          //Check for error type
          switch (error.status) {
            case 400:
              //Check if theres an error object that has an object called errors in it
              if (error.error.errors) {

                //Add a variable for modelstate errors
                const modelStateErrors = [];

                //Loop over each key in errors object
                for (const key in error.error.errors) {
                  if (error.error.errors[key]) {
                    //We flatten the errors we get back and push them into array
                    modelStateErrors.push(error.error.errors[key])
                  }
                }
                //Throw these modelstate errors back to the component so we can display a list of validation errors to user.
                //We use new JS feature to flaten our errors
                throw modelStateErrors.flat();
              }
              else {
                //Normal 400. Display Toast
                this.toastr.error(error.statusText, error.status);
              }
              break;

            case 401:
              this.toastr.error(error.statusText, error.status);
              break;

            case 404:
              //navigate them to not found page
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              //Get details of error
              //Redirect them to server error page

              //We must store the error in state. Using navigationExtras
              const navigationExtras: NavigationExtras = { state: { error: error.error } };

              //go to error page
              this.router.navigateByUrl('/server-error', navigationExtras);
              break;
            default:
              this.toastr.error('Something unexpected went wrong');
              console.log(error);
              break;
          }
        }
        //If the error is not caught in switch above we will return it here
        return throwError(error);
      })
    )
  }
}
