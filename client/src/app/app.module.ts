import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { CartComponent } from './cart/cart.component';
import { ProductsComponent } from './products/products.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductComponent } from './product/product.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { SharedModule } from './_modules/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeroComponent } from './hero/hero.component';
import { CheckoutSummaryComponent } from './checkout-summary/checkout-summary.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { NgxSpinner, NgxSpinnerModule } from 'ngx-spinner';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { MemberSubscriptionsComponent } from './subscription/subscription.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    CartComponent,
    ProductsComponent,
    ProductComponent,
    RegisterComponent,
    MemberEditComponent,
    LoginComponent,
    CheckoutComponent,
    HeroComponent,
    CheckoutSummaryComponent,
    TextInputComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TestErrorsComponent,
    ConfirmationComponent,
    MemberSubscriptionsComponent
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    //Import the shared module
    SharedModule,
    NgxSpinnerModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true/*multi:true means we don't want to replace existing interceptors. We want to add to the built in ones.*/ },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true/*multi:true means we don't want to replace existing interceptors. We want to add to the built in ones.*/ },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true/*multi:true means we don't want to replace existing interceptors. We want to add to the built in ones.*/ },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
