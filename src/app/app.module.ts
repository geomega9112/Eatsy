import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {NgOptimizedImage} from "@angular/common";
import { ForgotPasswordComponent } from './Eatsy/forgot-password/forgot-password.component';
import { LoginComponent } from './Eatsy/login/login.component';
import {ReactiveFormsModule} from "@angular/forms";
import { HomeComponent } from './pages/home/home.component';
import { ListComponent } from './pages/list/list.component';
import {RestaurantComponent} from "./pages/restaurant/restaurant.component";
import { PopularComponent } from './pages/popular/popular.component';
import { SupportComponent } from './pages/support/support.component';

@NgModule({
  declarations: [
    AppComponent,
    ForgotPasswordComponent,
    HomeComponent,
    ListComponent,
    RestaurantComponent,
    PopularComponent,
    SupportComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgOptimizedImage,
    ReactiveFormsModule,
    LoginComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
