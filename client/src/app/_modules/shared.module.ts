import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//Non angular imports go below
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  //Have to export these shared modules to make them available
  exports: [
    ToastrModule
  ]
})
export class SharedModule { }
