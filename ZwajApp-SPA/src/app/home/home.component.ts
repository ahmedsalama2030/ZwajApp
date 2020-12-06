import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode:any=true;
  values:any;
  
  constructor( private http:HttpClient,private authServices:AuthService,private route:Router) { }
  
  ngOnInit() {

    if(this.authServices.loggedIn){
      this.route.navigate(['/members']);
    }
    // this.getValues();
  }
  
  // getValues(){
  
  // this.http.get("http://localhost:5000/api/values").subscribe(
  // res=>{
  // this. values=res;
  // },
  // err=>{
  // console.log(err);
  // }
  // );
  
  // }

  cancelRegister(mode:any){
    console.log(mode)
    this.registerMode=mode;
  }
registerToggele(){
  this.registerMode=!(this.registerMode);
}

}

 
