import {Component, inject, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {HttpClient, HttpClientModule, HttpHeaders} from '@angular/common/http';

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
  isLogin: boolean = true; constructor(private httpClient: HttpClient) {}
  public Login: any[] = [
    {
      password: "Password",
      email: "Email"

    },
  ];
  public Regist: string[] = [

  ];
  toggleLoginView() {
    this.isLogin = !this.isLogin;
  }
  ngOnInit(): void {
    this.loginForm=this.fb.group({
      email:['',Validators.compose([Validators.required, Validators.email])],
      password:['',Validators.required],
      nickname:['',Validators.required]
    })
    // this.httpClient.get("https://localhost:7009/api/Users/Registration"),
    // this.Regist =&gt; {
    //   console.log(this.Regist),);

  }
  reset() {
    // Reset errors for all form controls
    this.loginForm.controls['email'].setErrors(null);
    this.loginForm.controls['password'].setErrors(null);
    this.loginForm.controls['nickname'].setErrors(null);
  }
  login()
  {
    console.log(this.loginForm.value);
  }
}


