import { Component } from '@angular/core';
import { AuthService } from '../services/AuthService';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HttpClientModule,CommonModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers: [AuthService]
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  login(): void {
    this.authService.login(this.username,this.password)
    .subscribe(
      (response: any) => {
        if (response && response.value && response.value.token) {
          const token = response.value.token;
          localStorage.setItem('token', token);
          this.router.navigate(['/urls']);
        } else {
          // catch exception
        }
      },
      (error) => {
        console.error('Login failed', error);
        console.log('Error response text:', error.error);
      }
    );
  }
}