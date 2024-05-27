import { Component } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterOutlet } from '@angular/router';
import { UrlDetailsComponent } from './url-details/url-details.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HttpClientModule,RouterOutlet,LoginComponent, RegisterComponent, CommonModule,UrlDetailsComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent { }
