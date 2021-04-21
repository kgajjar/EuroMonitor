import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  busy() {
    this.busyRequestCount++;
    //We wont give it a name so we set it as undefined
    this.spinnerService.show(undefined, {

      //Add some config properties
      //Check documentation for spinner types
      type: 'line-scale-party',

      //So we dont dim our background and just display spinner
      bdColor: 'rgba(255,255,255,0)',

      //Give the spinner a color
      color: '#333333'
    });
  }

  idle() {
    this.busyRequestCount--;

    //Check to see what our current busy request count is
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;

      //Hide spinner
      this.spinnerService.hide();
    }
  }
}
