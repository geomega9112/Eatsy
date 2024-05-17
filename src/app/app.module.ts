import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import { AgmCoreModule } from '@agm/core';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
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
import { MatIconModule } from "@angular/material/icon";
import { MatError } from "@angular/material/form-field";
import { MatIconButton } from "@angular/material/button";
import { MatTooltip } from "@angular/material/tooltip";
import {  MatSidenavModule } from "@angular/material/sidenav";
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';
import {MatSliderModule} from '@angular/material/slider';
import { MatSliderThumb } from "@angular/material/slider";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserComponent } from './pages/user/user.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MessagesComponent } from './messages/messages.component';

@NgModule({
  declarations: [
    AppComponent,
    ForgotPasswordComponent,
    HomeComponent,
    ListComponent,
    RestaurantComponent,
    PopularComponent,
    SupportComponent,
    UserComponent,
    MessagesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgOptimizedImage,
    ReactiveFormsModule,
    LoginComponent,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatSliderModule,
    MatError,
    MatTooltip,
    MatIconModule,
    MatIconButton,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSliderThumb,
    FontAwesomeModule,
    HttpClientModule,
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, { dataEncapsulation: false })
    // AgmCoreModule.forRoot({
    //   apiKey: 'YOUR_API_KEY'})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
