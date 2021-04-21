import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(component: MemberEditComponent): boolean {//Here we want to give it access to our MemberEdit Component so we can later check the status of our form inside here.
    //Check if form is dirty
    if (component.editForm.dirty) {
      //Return simple confirm from JS
      return confirm("Are you sure you want to continue? Any unsaved changes will be lost.");
    }
    return true;
  }

}
