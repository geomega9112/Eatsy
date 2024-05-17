import {Component, ViewEncapsulation, OnInit} from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
})
export class UserComponent implements OnInit {
  userForm: FormGroup;
  isEditMode = false;

  constructor(private fb: FormBuilder) {
    this.userForm = this.fb.group({
      name: [{ value: 'Михасик', disabled: true }],
      email: [{ value: 'misha2003@gmail.com', disabled: true }],
      //city: [{ value: 'Lviv', disabled: true }]
    });
  }

  ngOnInit() {}

  toggleEditMode() {
    this.isEditMode = !this.isEditMode;
    if (this.isEditMode) {
      this.userForm.enable();
    } else {
      this.userForm.disable();
      this.saveChanges();
    }
  }

  saveChanges() {
    console.log('User data saved:', this.userForm.value);
    // Here you can add code to send userForm.value to the server via an HTTP request
  }
}
