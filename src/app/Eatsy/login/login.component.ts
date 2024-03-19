import {Component, inject, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {RouterModule} from "@angular/router";

@Component({
  selector: 'app-login',
  standalone: true,
  imports:[CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  fb = inject(FormBuilder);
  loginForm !: FormGroup;
  isLogin: boolean = true; constructor() {}

  toggleLoginView() {
    this.isLogin = !this.isLogin;
  }
  ngOnInit(): void {
    this.loginForm=this.fb.group({
      email:['',Validators.compose([Validators.required, Validators.email])],
      password:['',Validators.required],
    });
  }
  login()
  {
    console.log(this.loginForm.value);
  }
}


