import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { User } from "../_models/user";
import { AlertifyService } from "../_services/alertify.service";
import { AuthService } from "../_services/auth.service";
import { UserService } from "../_services/user.service";

@Injectable()
export class MemberEditResolver implements Resolve<User>{
    
     
    constructor(private authServices:AuthService, private userService:UserService,private route:Router,private alertifyService:AlertifyService) {
         
    }
    
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):Observable<User> {
return this.userService.getUser(this.authServices.decodedToken.nameid).pipe(
catchError(error=>{
    this.alertifyService.error(error);
    this.route.navigate(['/members']);
    return of(null);
})
)

    }



    
}