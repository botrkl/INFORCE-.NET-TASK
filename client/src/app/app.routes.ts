import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { TableComponent } from './table/table.component';
import { UrlDetailsComponent } from './url-details/url-details.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'urls', component:TableComponent},
    { path: 'urls/:id', component: UrlDetailsComponent },
];
