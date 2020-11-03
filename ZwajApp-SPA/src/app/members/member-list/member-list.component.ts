import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../../_models/user';
import { AlertifyService } from '../../_services/alertify.service';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  users: User[];
  constructor(private route:ActivatedRoute,private userServices: UserService, private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(
      data=>{
        this.users=data['users'];
      }
    )
    //this.loadUsers();
  }
//   loadUsers() {
//     this.userServices.getUsers().subscribe((users: User[]) => {
//       this.users = users;
//     },
//       err => this.alertifyService.error(err)
    
//  );
//   }

}
