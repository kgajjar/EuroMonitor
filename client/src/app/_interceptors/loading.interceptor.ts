import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusyService } from '../_services/busy.service';
import { delay, finalize } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private busyService: BusyService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    //When we are about to call our API. Start Loader
    this.busyService.busy();

    //Once request comes back, we will turn off Spinner.
    return next.handle(request).pipe(
      //Add Fake delay for testing
      delay(1000),

      //Adding finalize will give us opportunity to do something when things have completed
      finalize(() => {
        this.busyService.idle();
      })
    );
  }
}
