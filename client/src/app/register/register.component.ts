import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //Input decorator to receive parent communication
  //@Input() usersFromHomeComponent: any;
  //Output decorator to send communication to parent. EventEmitter class.
  @Output() cancelRegistration = new EventEmitter();//EventEmitter allows us to emit value back to parent
 
  //Reactive Forms: Tracks the value and validity state of a group of form control instances.
  registerForm: FormGroup;

  validationErrors: string[] = [];

  //Inject account service in here.
  constructor(private router: Router, private accountService: AccountService, private toastr: ToastrService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    //Init Reactive Form
    this.initializeForm();
  }

  initializeForm() {
    //Reactive Forms: Initialize form
    this.registerForm = this.fb.group({
      //Here we specify form fields that we want to validate
      appUserName: ['', Validators.required],
      appUserFirstName: ['', Validators.required],
      appUserLastName: ['', Validators.required],
      appUserEmailAddress: ['', [Validators.required,Validators.email]],
      appUserContactNumber: ['', Validators.required],
      password: ['', [Validators.required,
      Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', [Validators.required,
      Validators.minLength(4),
      Validators.maxLength(25),
      this.matchValues('password')//Compare to password
      ]]
    });

    /*Problem: If we change password after we've already validated
      1) The password will show up as Valid. We fix this like this.
    */
    //Here we subscribe to the value changes
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      //So when password/confirmPassword, or either changes we will update the validity of that field against the confirm password field again.
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }

  /*Custom validator
  What are we doing?
  1) We are getting access to control we want to access this validator to
  2) We attach it to our confirm password control
  3) control?.value - is our confirmPassword control
  4) We go up and compare this to whatever we pass into the matchTo in - matchValues(matchTo: string): ValidatorFn
  5) We are passing in the password
  6) If passwords match - we return null [PASSED Validator]
  7) else we attach a validation error called isMatching to the control to fail form validation
  */
  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      //This gives us access to all controls in form
      return control?.value === control?.parent?.controls[matchTo].value
        ? null : { isMatching: true }//passing in what we are going to be matching this to.
    }
  }

  register() {
    //Reactive Forms: Contains the values for all of these Form Controls
    this.accountService.register(this.registerForm.value).subscribe(response => {

     this.router.navigateByUrl('cart');
    }, error => {
      //Take care of validation errors on client + backend. Just in case there is a mismatch
      //Set validation errors to error we get back from API
      this.validationErrors = error;
    });
  }
}

