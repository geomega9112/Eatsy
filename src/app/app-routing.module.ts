import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginComponent} from "./Eatsy/login/login.component";
import {ForgotPasswordComponent} from "./Eatsy/forgot-password/forgot-password.component";
import {HomeComponent} from "./pages/home/home.component";
import {ListComponent} from "./pages/list/list.component";
import {RestaurantComponent} from "./pages/restaurant/restaurant.component";
import {PopularComponent} from "./pages/popular/popular.component";
import {SupportComponent} from "./pages/support/support.component";
import {UserComponent} from "./pages/user/user.component";

const routes: Routes = [
  {path:'login', component: LoginComponent},
  {path:'forgot-password', component: ForgotPasswordComponent},
  {path:'home', component: HomeComponent},
  {path:'list', component: ListComponent},
  {path:'restaurant', component: RestaurantComponent},
  {path:'popular', component: PopularComponent},
  {path:'support', component: SupportComponent},
  {path:'user', component: UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
