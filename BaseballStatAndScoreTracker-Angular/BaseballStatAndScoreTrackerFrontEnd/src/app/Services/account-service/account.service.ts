import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ApiConstants } from '../../../Common/constants';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const loginData = { username, password };
    return this.http.post(ApiConstants.API_BASE_URL + ApiConstants.ACCOUNT_CONTROLLER + ApiConstants.AUTHENTICATE_ENDPOINT, loginData);
  }
}
