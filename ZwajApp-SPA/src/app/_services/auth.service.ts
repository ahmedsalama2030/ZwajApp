import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt/src/jwthelper.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
    helper = new JwtHelperService();
 decodedToken:any;
  baseUrl='http://localhost:5000/api/auth/';
constructor(private http:HttpClient) { }

login(model:any){
 
  return this.http.post(this.baseUrl +'login',model).pipe(
   map((response:any)=>{
     const user=response;
     if(user){localStorage.setItem('token',user.token);
     this.decodedToken=this.helper.decodeToken(user.token);

    }}) )
}
register(model:any){

  return this.http.post(this.baseUrl +'register',model);
}

loggedIn(){
  try{
  const token=localStorage.getItem('token');
  return ! this.helper.isTokenExpired(token);

  }catch{
    return false;
  }


}

}
