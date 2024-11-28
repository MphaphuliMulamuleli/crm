import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserLoginDto } from '../../models/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  user: UserLoginDto = { username: '', password: '' };

  constructor(private authService: AuthService) {}

  login() {
    this.authService.login(this.user).subscribe(response => {
      // Handle successful login and store token
    }, error => {
      // Handle error
    });
  }
} 