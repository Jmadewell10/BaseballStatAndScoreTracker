import { Component } from '@angular/core';
import { AccountService } from '../Services/account-service/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private accountService: AccountService) {}

  login() {
    this.accountService.login(this.username, this.password)
    .subscribe({
      next: value => 
      {
        console.log('Login Successful', value);
        const token = value.token;
        localStorage.setItem('token', token);
      },
      error: error => 
      {
        console.error('Login Failed', error)
      }
    });
  }

}
