 import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { ListsComponent } from "./lists/lists.component";
import { MemberDetailComponent } from "./members/member-detail/member-detail.component";
import { MemberEditComponent } from "./members/member-edit/member-edit.component";
import { MemberListComponent } from "./members/member-list/member-list.component";
import { MessagesComponent } from "./messages/messages.component";
import { AuthGuard } from "./_guards/auth.guard";
import { PreventChangesGuardGuard } from "./_guards/prevent-changes-guard.guard";
import { MemberDetailResolver } from "./_resolvers/member-detail.resolver";
import { MemberEditResolver } from "./_resolvers/member-edit.resolver";
import { MemberListResolver } from "./_resolvers/member-list.resolver";
  
 export const appRoutes:Routes=[
    {path:'',component:HomeComponent},
    {path:'',
runGuardsAndResolvers:'always',
canActivate:[AuthGuard] ,
children:[
    {path:'members',component:MemberListComponent ,resolve:{
        users:MemberListResolver
    }},
    {path:'member/edit',component:MemberEditComponent,resolve:{
        user:MemberEditResolver

    },canDeactivate:[PreventChangesGuardGuard]},

    {path:'members/:id',component:MemberDetailComponent,resolve:{
        user:MemberDetailResolver,
    } },
    {path:'lists',component:ListsComponent},
    {path:'messages',component:MessagesComponent} 
]

},

     
    {path:'**',redirectTo:'home',pathMatch:'full'}
 ];

 