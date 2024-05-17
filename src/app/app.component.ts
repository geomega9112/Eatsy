import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Eatsy2';
  // lat = 51.678418;
  // lng = 7.809007;
  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
  }
}
