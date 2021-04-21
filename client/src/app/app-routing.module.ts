import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { CartComponent } from './cart/cart.component';
import { ProductComponent } from './product/product.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutSummaryComponent } from './checkout-summary/checkout-summary.component';
import { AuthGuard } from './_gaurds/auth.guard';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { PreventUnsavedChangesGuard } from './_gaurds/prevent-unsaved-changes.guard';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { SubscriptionComponent } from './subscription/subscription.component';

const routes: Routes = [

  //The root will load home component
  { path: '', component: ProductsComponent },

  //Apply route guards to multiple routes
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      //We added our authgaurd below. Add it per link you want to protect.
      //Dont add a (s) on end as this will confuse Angular with the current members route.
      { path: 'member/edit', component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
      { path: 'checkoutsummary', component: CheckoutSummaryComponent },
      { path: 'confirmation', component: ConfirmationComponent },
      { path: 'subscription', component: SubscriptionComponent },
    ]
  },

  //Open to public
  { path: 'cart', component: CartComponent },
  { path: 'product/:id', component: ProductComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'checkout-summary', component: CheckoutSummaryComponent },

  //Register the error route outside routegaurd so we dont need to login
  { path: 'errors', component: TestErrorsComponent },

  //Register the not-found component route outside routegaurd so we dont need to login
  { path: 'not-found', component: NotFoundComponent },

  //Register the server-error component route outside routegaurd so we dont need to login
  { path: 'server-error', component: ServerErrorComponent },
  
  //Wildcard route: User has typed in a URL that doesn't match anything.
  //Direct them to homecomponent for now.
  //pathMatch full: If user doesn't match any of above then we will redirect them to ProductsComponent as it has to match full route.
  { path: '**', component: ProductsComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
