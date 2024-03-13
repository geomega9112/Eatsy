import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from "@angular/common";

@Component({
  selector: 'app-registration',
  standalone: true,
  imports:[CommonModule, ReactiveFormsModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent implements OnInit {
  fb = inject(FormBuilder);

  registrationForm !: FormGroup;

  ngOnInit(): void {
    this.registrationForm=this.fb.group({
      nickName:['',Validators.required],
      email:['',Validators.compose([Validators.required, Validators.email])],
      password:['',Validators.required],
    });
  }
}
