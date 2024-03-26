import { Component } from '@angular/core';
import { AccountService } from '../Services/account-service/account.service';
import { UserService } from '../Services/user-service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private accountService: AccountService,
     private userService: UserService,
     private router: Router
     ) {}

  

  login() {
    this.accountService.login(this.username, this.password)
    .subscribe({
      next: value => 
      {
        console.log('Login Successful', value);
        const token = value.token;
        localStorage.setItem('token', token);
        this.userService.loginUser();
        this.getAccountInfo();
        this.router.navigate(['/home']);
      },
      error: error => 
      {
        console.error('Login Failed', error);
      }
    });
  }

  getAccountInfo() {
    this.accountService.getAccount(this.username)
    .subscribe({
      next: value =>
      {
        console.log('Account', value);
        const accountId = value.accountId;
        localStorage.setItem('account', accountId);
      },
      error: error => 
      {
        console.error('Account info not found', error);
      }
    });
  }

}
