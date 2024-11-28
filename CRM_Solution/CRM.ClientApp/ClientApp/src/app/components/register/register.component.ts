import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserRegisterDto } from '../../models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user: UserRegisterDto = { username: '', password: '', email: '' };

  constructor(private authService: AuthService) {}

  register() {
    this.authService.register(this.user).subscribe(response => {
      // Handle successful registration
    }, error => {
      // Handle error
    });
  }
} 