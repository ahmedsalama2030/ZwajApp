import { Component, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode:any=true;
  values:any;
  
  constructor( private http:HttpClient) { }
  
  ngOnInit() {
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

 
