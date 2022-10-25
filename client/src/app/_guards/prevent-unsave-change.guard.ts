import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsaveChangeGuard implements CanDeactivate<unknown> {
  canDeactivate(
    component: MemberEditComponent):  boolean {
      if(component.editForm.dirty){
        return confirm('Are sure sure to continue? Any unsaved cahnges will be  lost');
      }
    return true;
  }
  
}
