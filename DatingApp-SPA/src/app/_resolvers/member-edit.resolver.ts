import { Injectable } from '@angular/core';
import { User } from '../_models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class MemberEditResolver implements Resolve<User> {
    constructor(private userService: UserService ,
        private authService: AuthService,
         private router: Router,
         private alertify: AlertifyService,) {}
        //  When we resolve we go out to the user services get the user that matches the parameters we are aiming to get
         resolve( route: ActivatedRouteSnapshot) : Observable<User>{
             // tslint:disable-next-line: no-string-literal
             return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
                 catchError(error => {
                   this.alertify.error('Problem retrieving your data')
                //    reroutes to members page if error occured
                   this.router.navigate(['/members']);
                   return of(null);
                 })
             )
         }
}