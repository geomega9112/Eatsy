import {Component, inject} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {RouterModule} from "@angular/router";

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.scss'
})
export class ForgotPasswordComponent {
  fb = inject(FormBuilder);
  forgotPasswordForm !: FormGroup;
  ngOnInit(): void {
    this.forgotPasswordForm=this.fb.group({
      email:['',Validators.compose([Validators.required, Validators.email])],
    });
  }
  submit()
  {
    console.log(this.forgotPasswordForm.value)
  }

}
