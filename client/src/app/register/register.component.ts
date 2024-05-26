import { Component } from '@angular/core';
import { AuthService } from '../services/AuthService';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,FormsModule,HttpClientModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
  providers: [AuthService]
})

export class RegisterComponent {
  username: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  register(): void {
    if (this.password !== this.confirmPassword) {
      console.error('Passwords do not match');
      return;
    }

    this.authService.register(this.username, this.password,this.confirmPassword)
      .subscribe(response => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/']);
      }, error => {
        console.error('Registration failed', error);
        console.log('Error response text:', error.error);
      });
  }
}