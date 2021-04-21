import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {

  //Make request to Login endpoint
  baseUrl = environment.apiUrl;//get api URL from dev enviroment
  
  validationErrors: string[] = [];

  //Inject http service so we can test our API
  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
  }

  //First method
  get404Error() {
    //Make http req
    //Then subscribe
    //Check response
    this.http.get(this.baseUrl + 'buggy/not-found').subscribe(response => {
      console.log(response);
    },
      error => {
        console.log(error);
      }
    )
  }

  get400Error() {
    //Make http req
    //Then subscribe
    //Check response
    this.http.get(this.baseUrl + 'buggy/bad-request').subscribe(response => {
      console.log(response);
    },
      error => {
        console.log(error);
      }
    )

  }

  get401Error() {
    //Make http req
    //Then subscribe
    //Check response
    this.http.get(this.baseUrl + 'buggy/auth').subscribe(response => {
      console.log(response);
    },
      error => {
        console.log(error);
      }
    )

  }

  get500Error() {
    //Make http req
    //Then subscribe
    //Check response
    this.http.get(this.baseUrl + 'buggy/server-error').subscribe(response => {
      console.log(response);
    },
      error => {
        console.log(error);
      }
    )

  }


  get400ValidationError() {
    //Make http req
    //Then subscribe
    //Check response
    this.http.post(this.baseUrl + 'account/register', {}/*Passing Empty object to throw error*/).subscribe(response => {
      console.log(response);
    },
      error => {
        console.log(error);
        this.validationErrors = error;
      }
    )

  }
}
