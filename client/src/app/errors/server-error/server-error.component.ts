import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {

  //Class property to hold error
  error: any;//type is any


  //Here we need to inject router so we have access to the router state and navigation extras
  constructor(private router: Router) {
    //We can only access the router state inside the constructor
    const navigation = this.router.getCurrentNavigation();

    //Here we use ?. Known as optional chaining operators
    //We check if the extras exist and if they contain an error
    this.error = navigation?.extras?.state?.error;
  }

  ngOnInit(): void {
  }

}
