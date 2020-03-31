import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }


  login() {
    this.authService.login(this.model).subscribe( next => {
      this.alertify.success('logged in successfully.');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // upon completion of action above, route the page to members page
      this.router.navigate(['/members']);
    });
  }
  // get token  the double ! is shorthand for true and false
loggedIn() {
  return this.authService.loggedIn();
}
// Remove authorising token from storrage therefroe logging out securely
logOut() {
  localStorage.removeItem('token');
  this.alertify.message('You have successfully logged out!');
  // upon completion of action above, route the page to home page
  this.router.navigate(['/home']);
}

}
