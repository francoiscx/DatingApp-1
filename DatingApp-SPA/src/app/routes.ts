import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
// Routes to the relevant pages
export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    // auth guard to multiple pages tp prevent outsiders from gaining access if not logged in
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent },
            { path: 'messages', component: MessagesComponent},
            { path: 'lists', component: ListsComponent},
        ]
    },
    // Wild card to redirect to home if none of the above matches the route(wild card always to be on the bottom)
    { path: '**', redirectTo: '', pathMatch: 'full'},

];
