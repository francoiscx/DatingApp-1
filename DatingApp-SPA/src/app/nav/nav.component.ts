import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }


  login(){
    this.authService.login(this.model).subscribe( next => {
      console.log('logged in successfully.');
    }, error => {
      console.log('Loggin unsuccessfull.');
    });
  }
  // get token  the double ! is shorthand for true and false
loggedIn(){
  const token = localStorage.getItem('token');
  return!!token;
}
// Remove authorising token from storrage therefroe logging out securely
logOut(){
  localStorage.removeItem('token');
  console.log('You have successfully logged out!');
}

}
