import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserRegisterDto, UserLoginDto } from '../models/user.model'; 

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5164/api/auth'; // Adjust based on your API URL

  constructor(private http: HttpClient) {}

  register(user: UserRegisterDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  login(user: UserLoginDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, user);
  }
} 