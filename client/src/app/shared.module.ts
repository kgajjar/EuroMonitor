import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { SubscriptionComponent } from './subscription/subscription.component';

@NgModule({
  declarations: [TextInputComponent, SubscriptionComponent],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
