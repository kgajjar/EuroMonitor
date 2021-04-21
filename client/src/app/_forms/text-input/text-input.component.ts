import { Input, Self } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})

//Acts as a bridge between Angular Native API and native element in the DOM
//formControlName="confirmPassword - This is our native element in the DOM"
//This is what we want access to
export class TextInputComponent implements ControlValueAccessor {
  @Input() label: string;
  @Input() type = 'text';//input type text by default

  //Inject the control into this ctor
  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }
  writeValue(obj: any): void {
  }
  registerOnChange(fn: any): void {
  }
  registerOnTouched(fn: any): void {
  }
}
