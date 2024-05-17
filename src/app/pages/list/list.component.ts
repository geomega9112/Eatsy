import { Component, OnInit, Input, Output, EventEmitter, ViewEncapsulation } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import {HttpClient, HttpClientModule, HttpHeaders} from '@angular/common/http';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
  encapsulation: ViewEncapsulation.Emulated  // Ensures style encapsulation for this component
})
export class ListComponent implements OnInit {
  public currentRating: number = 0;
  @Input('rating') private rating: number = 3;  // Default rating
  @Input('starCount') public starCount: number = 5;  // Total number of stars
  @Input('color') public color: string = 'accent';  // Color for active stars
  @Output() private ratingUpdated = new EventEmitter<number>();  // Emits the selected rating

  public ratingArr: number[] = [];  // Array to hold the stars for ngFor
  public restaurants: any[] = [

  ];

  constructor(private snackBar: MatSnackBar, private httpClient: HttpClient) {

  }
  selectedCheckbox: string | null = null;
  selectedReservationCheckbox: string | null = null;

  moveCheckbox(id: string): void {
    this.selectedCheckbox = id;
  }

  moveReservationCheckbox(id: string): void {
    this.selectedReservationCheckbox = id;
  }

  ngOnInit() {
    this.initializeStars();
    this.httpClient.get("https://localhost:7009/api/GetRestaurants")
      .subscribe(
        res => {
          console.log('HTTP response', res)
          this.restaurants = [
            {
              name: "YOKI Restaurant",
              address: "вулиця Академіка Гнатюка, 12а",
              img: "assets/yoki.png"
            },
            {
              name: "Піцерія 'Італійська смакота'",
              address: "вулиця Академіка Гнатюка, 12а",
              img: "assets/yoki.png"
            },
            {
              name: "YOKI Restaurant",
              address: "вулиця Академіка Гнатюка, 12а",
              img: "/assets/yoki.png"
            },
            {
              name: "YOKI Restaurant",
              address: "вулиця Академіка Гнатюка, 12а",
              img: "assets/yoki.png"
            }
          ]
        },
        err => console.log('HTTP Error', err),);
  }

  // Initializes the stars based on starCount
  private initializeStars(): void {
    this.ratingArr = Array.from({ length: this.starCount }, (_, index) => index);
    console.log(`Initialized ${this.starCount} stars.`);
  }

  // Handles click on star, updates the rating, and shows a snack bar
  onClick(rating: number): boolean {
    this.rating = rating;
    this.snackBar.open(`You rated ${rating} / ${this.starCount}`, '', {
      duration: 2000  // Can use the class property if it needs to be configurable
    });
    this.ratingUpdated.emit(this.rating);  // Emit the new rating value
    return false;  // Prevent default form submission behavior if needed
  }

  // Determines which icon to show based on the current rating
  showIcon(index: number): string {
    return this.rating >= index + 1 ? 'star' : 'star_border';
  }

  // Optional: Format label for display, useful in other parts of the component if needed
  formatLabel(value: number): string {
    return value >= 1000 ? `${Math.round(value / 1000)}k` : `${value}`;
  }
}

// Enum for defining possible color choices for the stars
export enum StarRatingColor {
  primary = "primary",
  accent = "accent",
  warn = "warn"
}

