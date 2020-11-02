import { Component, OnInit ,Input, Output, EventEmitter} from '@angular/core';
import { AuthService } from '../_services/auth.service';
 
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {};
  @Input() valuesFromRegister:any;
  @Output() cancelRegister=new EventEmitter ();

  constructor(private authservice:AuthService) { }

  ngOnInit() {
  }

  register() {
this.authservice.register(this.model).subscribe(
  ()=>{console.log("Ok ")},
  
  err=>{console.log(err)}
);
    
  }
  cancel() {
     this.cancelRegister.emit(true);
  }


}
