import { Component } from '@angular/core';
import { UserService } from '../Services/user-service/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(private userService: UserService) {}
  isLoggedIn: boolean = false;

  ngOnInit() {
    // Subscribe to changes in the user's login state
    this.userService.isLoggedIn.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn;
    });
  }

  logout() {
    // Call the logout method of the UserService
    this.userService.logoutUser();
  }

}
