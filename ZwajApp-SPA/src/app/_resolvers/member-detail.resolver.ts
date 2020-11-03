import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { User } from "../_models/user";
import { AlertifyService } from "../_services/alertify.service";
import { UserService } from "../_services/user.service";

@Injectable()
export class MemberDetailResolver implements Resolve<User>{
    
     
    constructor( private userService:UserService,private route:Router,private alertifyService:AlertifyService) {
         
    }
    
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):Observable<User> {
return this.userService.getUser(route.params['id']).pipe(
catchError(error=>{
    this.alertifyService.error(error);
    this.route.navigate(['/members']);
    return of(null);
})
)

    }



    
}