import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {

  @ViewChild ('editForm') editForm:NgForm

  user:User
  @HostListener('window:beforeunload',['$event'])
  unLoadNotification($event:any){
    if(this.editForm.dirty){
      $event.returnValue=true;
    }
  }
  constructor(private alertify:AlertifyService,private route :ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(
      data=>{
this.user=data['user'];
          })
        }


        updateUser(){
          this.editForm.reset(this.user);
this.alertify.success('Ok');
        }

}
