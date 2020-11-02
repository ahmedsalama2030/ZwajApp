import { Component, OnInit ,Input, Output, EventEmitter} from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
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

  constructor(private authservice:AuthService,private alertify:AlertifyService) { }

  ngOnInit() {
  }

  register() {
this.authservice.register(this.model).subscribe(
  ()=>{this.alertify.success('تم  الاشترك ') },
  
  err=>{this.alertify.error(err)}
  );
    
  }
  cancel() {
     this.cancelRegister.emit(true);
  }


}
