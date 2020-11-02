import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
 
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
   
  constructor(private router:Router,private authservice:AuthService,private alertify:AlertifyService) {
     
  }
  canActivate():  boolean {
    if(this.authservice.loggedIn()) {
      return true;

    }
      this.alertify.error('يجب تسجيل ولا');
      this.router.navigate(['']);
      return false;

   }
}
