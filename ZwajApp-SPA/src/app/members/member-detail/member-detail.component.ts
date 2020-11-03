import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from 'ngx-gallery';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  user:User;
  constructor(private route:ActivatedRoute,private userServices: UserService, private alertifyService: AlertifyService) { }

  ngOnInit() {
  //this.loadUser();
this.route.data.subscribe(
  data=>{
    this.user=data['user'];
  }
);
this.galleryOptions=this.galleryOptions = [
  {
      width: '500px',
      height: '500px',
      imagePercent: 100,
      thumbnailsColumns: 4,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview:false
  },
  // max-width 800
  {
      breakpoint: 800,
      width: '100%',
      height: '600px',
      imagePercent: 80,
      thumbnailsPercent: 20,
      thumbnailsMargin: 20,
      thumbnailMargin: 20
  },
  // max-width 400
  {
      breakpoint: 400,
      preview: true
  }
];

this.galleryImages =  this.getImages();


  }

getImages(){
const imageUrls=[];
  for(let i=0;i<this.user.photos.length;i++){
    imageUrls.push({
      small:this.user.photos[i].url,
      medium:this.user.photos[i].url,
      big:this.user.photos[i].url,
       
    })
  };
  return imageUrls;
}

  // loadUser(){
  //   this.userServices.getUser(+this.route.snapshot.params['id']).subscribe(
  //  (user:User)=>{ this.user=user},
  //  error=>{this.alertifyService.error(error)}


  //   );
  // }

}
