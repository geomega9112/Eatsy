import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'login', loadComponent: ()=> import('./Eatsy/login/login.component').then(a=>a.LoginComponent)},
  {path: 'registration', loadComponent: ()=> import('./Eatsy/registration/registration.component').then(a=>a.RegistrationComponent)},
  {path: 'forgot-password', loadComponent: ()=> import('./Eatsy/forgot-password/forgot-password.component').then(a=>a.ForgotPasswordComponent)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
